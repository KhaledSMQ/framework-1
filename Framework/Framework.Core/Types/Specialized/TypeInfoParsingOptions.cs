// ============================================================================
// Project: Framework
// Name/Class: TypeInfoParsingOptions
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 9/Oct/2016
// Company: Coop4Creativity
// Description: Parsing options for type infos.
// ============================================================================

namespace Framework.Core.Types.Specialized
{
    public class TypeInfoParsingOptions
    {
        //
        // DEFAULTS
        //

        public const char DEFAULT_PARSING_ASSEMBLY_SEPARATOR = ':';
        public const char DEFAULT_PARSING_SEPARATOR_CHARATER = ',';
        public const char DEFAULT_PARSING_OPEN_GENERIC_CHARACTER = '[';
        public const char DEFAULT_PARSING_CLOSE_GENERIC_CHARACTER = ']';

        //
        // Default parsing option configuration.
        //

        public static readonly TypeInfoParsingOptions DEFAULT = new TypeInfoParsingOptions();

        //
        // PArsing configuration options.
        //

        public char AssemblySeparatorChar { get; set; }

        public char SeparatorChar { get; set; }

        public char OpenGenericChar { get; set; }

        public char CloseGenericChar { get; set; }

        //
        // CONSTRUCTOR
        //

        public TypeInfoParsingOptions()
        {
            AssemblySeparatorChar = DEFAULT_PARSING_ASSEMBLY_SEPARATOR;
            SeparatorChar = DEFAULT_PARSING_SEPARATOR_CHARATER;
            OpenGenericChar = DEFAULT_PARSING_OPEN_GENERIC_CHARACTER;
            CloseGenericChar = DEFAULT_PARSING_CLOSE_GENERIC_CHARACTER;
        }              
    }
}
