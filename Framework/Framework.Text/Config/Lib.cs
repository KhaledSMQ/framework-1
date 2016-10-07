// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

namespace Framework.Text.Config
{
    public class Lib : Core.Config.ModuleConfiguration
    {
        // 
        // Error prefix for error messages in this library.
        //

        public static readonly string DEFAULT_ERROR_MSG_PREFIX = Base.GetDefaultErrorPrefix(System.Reflection.Assembly.GetExecutingAssembly());

        // 
        // Default Xml namespace.
        //

        public static readonly string DEFAULT_XML_NAMESPACE = Base.GetDefaultXmlNamespace(System.Reflection.Assembly.GetExecutingAssembly());

        //
        // Default config section name for library.
        //

        public static readonly string DEFAULT_CONFIG_SECTION_NAME = Base.GetConfigSectionName(System.Reflection.Assembly.GetExecutingAssembly());

        //
        // Error handling for exceptions.
        //

        public static readonly Core.Error.ExceptionHandler Exception = Base.GetExceptionHandler(System.Reflection.Assembly.GetExecutingAssembly(), ErrorMessages.DEFAULT);
    }
}
