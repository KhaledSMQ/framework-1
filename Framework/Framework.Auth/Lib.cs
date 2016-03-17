// ============================================================================
// Project: Framework
// Name/Class: Config
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration object.
// ============================================================================

using Framework.Core.Extensions;
using System.Reflection;

namespace Framework.Auth
{
    public static class Lib
    {
        // 
        // Default Xml namespace.
        //

        public static string DEFAULT_XML_NAMESPACE = Framework.Lib.DEFAULT_XML_NAMESPACE + "/" + DEFAULT_ERROR_MSG_PREFIX.RightOf(".").Replace('.', '/').ToLower();

        // 
        // Error prefix for error messages in this library.
        //

        public static string DEFAULT_ERROR_MSG_PREFIX = Assembly.GetExecutingAssembly().GetName().Name;
    }
}
