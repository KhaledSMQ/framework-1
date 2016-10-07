// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

namespace Framework.Types.Config
{
    public enum Error
    {
        UNKNOWN
    }

    public static class ErrorMessages
    {
        public static readonly object[] DEFAULT = new object[] {

            Error.UNKNOWN, "unknown error '{0}'"

        };
    }
}
