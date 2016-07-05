// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 29/July/2013
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections.Specialized;
using System.Web;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public class XslQueryStringExtension : IXsltExtensionObject
    {
        //
        // SINGLETON
        //

        public static IXsltExtensionObject Instance
        {
            get { return (_Instance = (_Instance == null) ? new XslQueryStringExtension() : _Instance); }
        }

        //
        // PROPERTIES
        //

        public string NamespaceUri { get { return Lib.DEFAULT_XML_NAMESPACE + "/xsl/qs"; } }

        //
        // CONSTRCUTORS
        //

        private XslQueryStringExtension() { }

        //
        // EXPOSED METHODS
        //

        public string GetValue(string paramName)
        {
            NameValueCollection qs = HttpContext.Current.Request.QueryString;
            return GetQueryStringValue(qs, paramName, string.Empty);
        }

        public string GetValueWithDefault(string paramName, string defaultValue)
        {
            NameValueCollection qs = HttpContext.Current.Request.QueryString;
            return GetQueryStringValue(qs, paramName, defaultValue);
        }

        //
        // HELPERS
        //

        private static string GetQueryStringValue(NameValueCollection qs, string name, string defaultValue)
        {
            string retValue = string.IsNullOrEmpty(defaultValue) ? string.Empty : defaultValue;

            if (null != qs[name])
            {
                retValue = qs[name];
            }

            return retValue;
        }

        //
        // PRIVATE FIELDS
        //

        private static XslQueryStringExtension _Instance = null;
    }
}
