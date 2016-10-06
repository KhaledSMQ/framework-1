// ============================================================================
// Project: Framework
// Name/Class: XslHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helpers for Xslt transformations.
// ============================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Framework.Core.Extensions;

namespace Framework.Core.Helpers
{
    public static class XslHelper
    {
        //
        // XSL CUSTOM FUNCTIONS
        //

        //public static XsltArgumentList CustomFunctions
        //{
        //    get
        //    {
        //        XsltArgumentList __CustomFunctions = new XsltArgumentList();
        //        __CustomFunctions.AddExtensionObject(Framework.Core.Xsl.Config.TOOLKIT_XSL_DATE, XslDateExtension.Instance);
        //        __CustomFunctions.AddExtensionObject(Framework.Core.Xsl.Config.TOOLKIT_XSL_QUERYSTRING, XslQueryStringExtension.Instance);
        //        __CustomFunctions.AddExtensionObject(Framework.Core.Xsl.Config.TOOLKIT_XSL_URL, XslUrlExtension.Instance);
        //        return __CustomFunctions;
        //    }
        //}

        //
        // Transform with a variable list of arguments.
        //

        public static string Transform(string xmlDocUrl, string xslDocUrl, params object[] args)
        {
            return Transform(xmlDocUrl, xslDocUrl, args.ToList());
        }

        public static string Transform(XDocument xmlDoc, string xslDocUrl, params object[] args)
        {
            return Transform(xmlDoc, xslDocUrl, args.ToList());
        }

        public static string Transform(string xmlDocUrl, XslCompiledTransform xslDoc, params object[] args)
        {
            return Transform(xmlDocUrl, xslDoc, args.ToList());
        }

        public static string Transform(XDocument xmlDoc, XslCompiledTransform xslDoc, params object[] args)
        {
            return Transform(xmlDoc, xslDoc, args.ToList());
        }

        //
        // Transform with a enumerable of arguments.
        //

        public static string Transform(string xmlDocUrl, string xslDocUrl, IEnumerable<object> args)
        {
            XDocument xmlDoc = XDocument.Load(xmlDocUrl);
            XslCompiledTransform xslDoc = new XslCompiledTransform();
            xslDoc.Load(xslDocUrl);
            return Transform(xmlDoc, xslDoc, args);
        }

        public static string Transform(XDocument xmlDoc, string xslDocUrl, IEnumerable<object> args)
        {
            XslCompiledTransform xslDoc = new XslCompiledTransform();
            xslDoc.Load(xslDocUrl);
            return Transform(xmlDoc, xslDoc, args);
        }

        public static string Transform(string xmlDocUrl, XslCompiledTransform xslDoc, IEnumerable<object> args)
        {
            XDocument xmlDoc = XDocument.Load(xmlDocUrl);
            return Transform(xmlDoc, xslDoc, args);
        }

        public static string Transform(XDocument xmlDoc, XslCompiledTransform xslDoc, IEnumerable<object> args)
        {
            //
            // Buffer where the generated output will be stored.
            //

            StringWriter stringBuffer = new StringWriter();

            //
            // Process arguments to Xsl, i.e. extension objects.
            //

            XsltArgumentList xsltArgs = _ToXsltArgumentList(args);

            //
            // Apply Xslt transformation.
            //

            xslDoc.Transform(xmlDoc.CreateReader(), xsltArgs, stringBuffer);

            //
            // Return the output to caller.
            //

            return stringBuffer.ToString();
        }

        //
        // HELPERS
        //

        private static XsltArgumentList _ToXsltArgumentList(IEnumerable<object> args)
        {
            XsltArgumentList xsltArgs = new XsltArgumentList();

            //
            // Two types of object that can be added:
            //   - Simple parameters
            //   - Extension Objects
            //

            bool isParam = false;

            string paramName = string.Empty;
            string paramNSUri = string.Empty;
            string paramValue = string.Empty;

            string extNSUri = string.Empty;
            object extObject = null;

            //
            // Add parameters and extension objects.
            //

            if (isParam)
            {
                xsltArgs.AddParam(paramName, paramNSUri, paramValue);
            }
            else
            {
                xsltArgs.AddExtensionObject(extNSUri, extObject);
            }

            return xsltArgs;
        }

        //
        // Base Url Xml resolver.
        //

        class DefaultServerXmlUrlResolver : XmlUrlResolver
        {
            private string _BaseUrl = string.Empty;

            public DefaultServerXmlUrlResolver(string baseUrl)
            {
                _BaseUrl = baseUrl;
            }

            public override Uri ResolveUri(Uri baseUri, string relativeUri)
            {
                if (baseUri.IsNotNull())
                {
                    return base.ResolveUri(baseUri, relativeUri);
                }
                else
                {
                    return base.ResolveUri(new Uri(_BaseUrl), relativeUri);
                }
            }
        }
    }
}
