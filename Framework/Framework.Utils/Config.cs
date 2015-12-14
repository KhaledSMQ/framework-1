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

namespace Framework.Utils
{
    public static class Config
    {
        // 
        // Default Xml namespace.
        //

        public static string DEFAULT_XML_NAMESPACE = Framework.Config.DEFAULT_XML_NAMESPACE + "/" + Assembly.GetExecutingAssembly().GetName().FullName.RightOf(".").Replace('.', '/').ToLower();

        // 
        // Error prefix for error messages in this library.
        //

        public static string DEFAULT_ERROR_MSG_PREFIX = Assembly.GetExecutingAssembly().GetName().FullName;
    }
}
