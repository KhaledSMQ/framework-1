// ============================================================================
// Project: Toolkit Apps
// Name/Class: Config
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Aug/2015
// Company: Cybermap Lta.
// Description: Configuration object.
// ============================================================================

using System.Reflection;

namespace Framework.CMS1
{
    public static class Config
    {
        // 
        // Default Xml namespace.
        //

        public const string DEFAULT_XML_NAMESPACE = Toolkit.Config.DEFAULT_XML_NAMESPACE + "/cms";

        // 
        // Error prefix for error messages in this library.
        //

        public static string DEFAULT_ERROR_MSG_PREFIX = Assembly.GetExecutingAssembly().GetName().FullName;
    }
}
