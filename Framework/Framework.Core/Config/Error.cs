// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

namespace Framework.Core.Config
{
    public enum Error
    {
        UNKNOWN,

        //
        // MimeTypes
        //

        UNABLE_TO_DETERMINE_MIME_TYPE_FROM_FILENAME,
        UNABLE_TO_DETERMINE_FILE_EXTENSION_FROM_MIME_TYPE
    }

    public static class ErrorMessages
    {
        public static readonly object[] DEFAULT = new object[] {

            Error.UNKNOWN, "unknown error '{0}'",

            //
            // MimeTypes
            //

            Error.UNABLE_TO_DETERMINE_MIME_TYPE_FROM_FILENAME, "unable to determine mime type for filename '{1}",
            Error.UNABLE_TO_DETERMINE_FILE_EXTENSION_FROM_MIME_TYPE, "unable to determine file extension from mime type '{1}"


        };
    }
}
