// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

namespace Framework.Client.Config
{
    public class Lib : Core.Config.ModuleConfiguration
    {
        // 
        // Error prefix for error messages in this library.
        //

        public static readonly string DEFAULT_ERROR_MSG_PREFIX = Framework.Lib.GetDefaultErrorPrefix(System.Reflection.Assembly.GetExecutingAssembly());

        // 
        // Default Xml namespace.
        //

        public static readonly string DEFAULT_XML_NAMESPACE = Framework.Lib.GetDefaultXmlNamespace(System.Reflection.Assembly.GetExecutingAssembly());

        //
        // Default config section name for library.
        //

        public static readonly string DEFAULT_CONFIG_SECTION_NAME = Framework.Lib.GetConfigSectionName(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
