// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================            

using Framework.Core.Extensions;
using System;
using System.Web;

namespace Framework.Web.Extensions
{
    public static class PageExtensions
    {
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
