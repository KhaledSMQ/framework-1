// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 29/July/2013
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Web;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public class XslUrlExtension : IXsltExtensionObject
    {
        //
        // SINGLETON
        //

        public static IXsltExtensionObject Instance
        {
            get { return (_Instance = (_Instance == null) ? new XslUrlExtension() : _Instance); }
        }

        //
        // PROPERTIES
        //

        public string NamespaceUri { get { return Lib.DEFAULT_XML_NAMESPACE + "/xsl/url"; } }

        //
        // CONSTRCUTORS
        //

        private XslUrlExtension() { }

        //
        // EXPOSED METHODS
        //

        public string Encode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        public string Decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        //
        // PRIVATE FIELDS
        //

        private static XslUrlExtension _Instance = null;
    }
}
