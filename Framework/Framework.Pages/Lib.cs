// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

namespace Framework.Pages
{
    public static class Lib
    {
        // 
        // Error prefix for error messages in this library.
        //

        public static string DEFAULT_ERROR_MSG_PREFIX = Framework.Lib.GetDefaultErrorPrefix(System.Reflection.Assembly.GetExecutingAssembly());

        // 
        // Default Xml namespace.
        //

        public static string DEFAULT_XML_NAMESPACE = Framework.Lib.GetDefaultXmlNamespace(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
