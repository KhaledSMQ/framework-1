// ============================================================================
// Project: Toolkit (Web)
// Name/Class: PageExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 13/Jun/2013
// Company: Cybermap Lta.
// Description: Set of extension methods for web pages.
// ============================================================================                    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Framework.Core.Extensions;
using Framework.Types.Specialized;

namespace Framework.Web.Extensions
{
    public static class PageExtensions
    {
        //
        // CONSTANTS
        //

        private const string HttpRequestIsAvailable = "HttpRequestIsAvailable";

        #region Style & Script Adhoc

        public static void RegisterStyleResource(this Page page, string resource, string media = "all")
        {
            // check if the head is a server control, if not
            // warn the user/developer
            if (page.Header == null)
            {
                throw new NotSupportedException("No <head runat=server> control found in page.");
            }

            // initialize the key control
            HtmlControl styleControl = null;

            // preprocess media value
            string actualMedia = (string.IsNullOrEmpty(media)) ? "all" : media;

            if (resource.IsUri())
            {
                // check if this file was already registered
                var alreadyRegistered = page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals(resource));
                if (alreadyRegistered) return;

                // if resource is a FILE generate a link element
                HtmlLink linkTag = new HtmlLink();
                linkTag.Href = resource;
                linkTag.Attributes["rel"] = "stylesheet";
                linkTag.Attributes["type"] = "text/css";
                linkTag.Attributes["media"] = actualMedia;
                styleControl = linkTag;
            }
            else
            {
                // if it is not a link, it must must a string with the key inside,
                // in this case add a key tag
                HtmlGenericControl styleTag = new HtmlGenericControl("style");
                styleTag.Attributes["type"] = "text/css";
                styleTag.Attributes["media"] = actualMedia;
                styleTag.InnerText = resource;
                styleControl = styleTag;
            }

            // finally, add the generated control to the page header
            page.Header.Controls.Add(styleControl);
        }

        public static void RegisterSetOfStyleResources(this Page page, string resources, char separator = '|')
        {
            page.RegisterSetOfStyleResources(resources.SplitNoEmpty(separator));
        }

        public static void RegisterSetOfStyleResources(this Page page, params string[] resource)
        {
            foreach (string res in resource) { page.RegisterStyleResource(res); }
        }

        public static void RegisterScriptResource(this Page page, string resource)
        {
            if (resource.IsUri())
            {
                // if key is an address, register the file with page
                if (!page.ClientScript.IsClientScriptIncludeRegistered(resource))
                {
                    page.ClientScript.RegisterClientScriptInclude(resource, resource);
                }
            }
            else
            {
                string scriptFragment = string.Empty;
                scriptFragment += "<script language=\"javascript\">";
                scriptFragment += resource;
                scriptFragment += "<" + "/script>";

                // register the key block of the page
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), resource, scriptFragment);
            }
        }

        public static void RegisterSetOfScriptResources(this Page page, string resources, char separator = '|')
        {
            page.RegisterSetOfScriptResources(resources.SplitNoEmpty(separator));
        }

        public static void RegisterSetOfScriptResources(this Page page, params string[] resource)
        {
            foreach (string res in resource) { page.RegisterScriptResource(res); }
        }

        #endregion

        #region Resource Objects

        public static void RegisterResource(this Page page, IEnumerable<WebResource> lst)
        {
            lst.Apply(page.RegisterResource);
        }

        public static void RegisterResource(this Page page, params WebResource[] lst)
        {
            RegisterResource(page, lst);
        }

        public static void RegisterResource(this Page page, WebResource resx)
        {
            RegisterResource(page, page, resx);
        }

        public static void RegisterResource(this Page page, Control ctrl, IEnumerable<WebResource> lst)
        {
            lst.Apply(res => page.RegisterResource(ctrl, res));
        }

        public static void RegisterResource(this Page page, Control ctrl, params WebResource[] lst)
        {
            RegisterResource(page, ctrl, lst);
        }

        public static void RegisterResource(this Page page, Control ctrl, WebResource resx)
        {
            switch (resx.Type)
            {
                case WebResource.TypeOfResource.SCRIPT:
                    {
                        switch (resx.Source)
                        {                           
                            case WebResource.TypeOfSource.REMOTE:
                                {
                                    // include the resource only once.
                                    if (!page.ClientScript.IsClientScriptIncludeRegistered(resx.Value))
                                    {
                                        page.ClientScript.RegisterClientScriptInclude(resx.Value, resx.Value);
                                    }
                                }
                                break;
                            case WebResource.TypeOfSource.INLINE:
                                {
                                    string scriptFragment = string.Empty;
                                    scriptFragment += "<script language=\"javascript\">";
                                    scriptFragment += resx.Value;
                                    scriptFragment += "<" + "/script>";

                                    // register the key block of the page
                                    page.ClientScript.RegisterStartupScript(page.GetType(), resx.Value, scriptFragment);
                                }
                                break;
                        }
                    }
                    break;
                case WebResource.TypeOfResource.STYLE:
                    {
                        switch (resx.Source)
                        {
                            case WebResource.TypeOfSource.REMOTE:
                                page.RegisterStyleResource(resx.Value, resx.Media);
                                break;
                            case WebResource.TypeOfSource.INLINE:
                                page.RegisterStyleResource(resx.Value, resx.Media);
                                break;
                        }
                    }
                    break;
            }
        }

        #endregion

        #region Get Embedded Resources

        public static string GetEmbeddedResourceUrl(this Page currentPage, Control control, string prefix, string name, bool absolute = true)
        {
            return GetEmbeddedResourceUrl(currentPage, control.GetType(), prefix, name, absolute);
        }

        public static string GetEmbeddedResourceUrl(this Page currentPage, Type currentType, string prefix, string name, bool absolute = true)
        {
            return GetEmbeddedResourceUrl(currentPage, currentType, prefix + name, absolute);
        }

        public static string GetEmbeddedResourceUrl(this Page currentPage, Control control, string dotPath, bool absolute = true)
        {
            return GetEmbeddedResourceUrl(currentPage, control.GetType(), dotPath, absolute);
        }

        public static string GetEmbeddedResourceUrl(this Page currentPage, Type currentType, string dotPath, bool absolute = true)
        {
            string url = currentPage.ClientScript.GetWebResourceUrl(currentType, dotPath);
            return absolute ? url.AbsoluteUri() : url;
        }

        #endregion

        //
        // Return the current fully qualified application path of a web application.
        // Includes host, port, etc.
        //

        public static string ApplicationPath()
        {
            return ApplicationPath(HttpContext.Current);
        }

        public static string ApplicationPath(HttpContext context)
        {
            // 
            // Return value.
            //

            string appPath = string.Empty;

            //
            // Check if context is valid and contains the http request.
            //

            if (null != context)
            {
                try
                {
                    // 
                    // formatting the fully qualified website url/name
                    //

                    appPath = string.Format("{0}://{1}{2}{3}", context.Request.Url.Scheme, context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port, context.Request.ApplicationPath);

                    if (!appPath.EndsWith("/"))
                    {
                        appPath += "/";
                    }
                }
                catch (Exception) { }
            }

            return appPath;
        }

        public static string HostPath()
        {
            return HostPath(HttpContext.Current);
        }

        public static string HostPath(HttpContext context)
        {
            // 
            // Return value.
            //

            string hostPath = string.Empty;

            //
            // Check if context is valid and contains the http request.
            //

            if (null != context)
            {
                try
                {
                    //
                    // Format the host path.
                    //

                    hostPath = string.Format("{0}://{1}{2}", context.Request.Url.Scheme, context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port);

                    if (!hostPath.EndsWith("/"))
                    {
                        hostPath += "/";
                    }
                }
                catch (Exception) { }
            }

            return hostPath;
        }

        public static string HostNoProtocol()
        {
            return HostNoProtocol(HttpContext.Current);
        }

        public static string HostNoProtocol(HttpContext context)
        {
            //
            // Return value.
            //

            string hostPath = string.Empty;

            //
            // Check if context is valid and contains the http request.
            //

            if (null != context)
            {
                try
                {
                    hostPath = string.Format("{0}{1}", context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port);

                    if (hostPath.EndsWith("/"))
                    {
                        hostPath = hostPath.ChopEnd(1);
                    }
                }
                catch (Exception) { }
            }

            return hostPath;
        }
    }
}
