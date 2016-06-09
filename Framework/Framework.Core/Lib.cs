// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using System.Reflection;

namespace Framework
{
    public static class Lib
    {
        // 
        // Default Xml namespace for the base namespace.
        //

        public const string DEFAULT_XML_NAMESPACE = "http://framework.cybermap.pt/";

        //
        // Static methods for assembly/lib values.
        //

        public static string GetDefaultErrorPrefix(Assembly executingAssembly)
        {
            return executingAssembly.GetName().Name;
        }

        public static string GetDefaultXmlNamespace(Assembly executingAssembly)
        {
            return DEFAULT_XML_NAMESPACE + "/" + GetDefaultErrorPrefix(executingAssembly).RightOf(".").Replace('.', '/').ToLower();
        }
    }
}

namespace Framework.Core
{
    public static class Lib
    {
        // 
        // Error prefix for error messages in this library.
        //

        public static string DEFAULT_ERROR_MSG_PREFIX = Framework.Lib.GetDefaultErrorPrefix(Assembly.GetExecutingAssembly());

        // 
        // Default Xml namespace.
        //

        public static string DEFAULT_XML_NAMESPACE = Framework.Lib.GetDefaultXmlNamespace(Assembly.GetExecutingAssembly());
    }
}
