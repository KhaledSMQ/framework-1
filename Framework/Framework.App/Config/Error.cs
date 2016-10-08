// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

namespace Framework.App.Config
{
    public enum Error
    {
        UNKNOWN,

        //
        // Container Service
        //

        CONTAINER_SERVICE_NOT_DEFINED,
        CONTAINER_SERVICE_ALREADY_DEFINED
    }

    public static class ErrorMessages
    {
        public static readonly object[] DEFAULT = new object[] {

            Error.UNKNOWN, "unknown error '{0}'",

            //
            // Container service.
            //

            Error.CONTAINER_SERVICE_NOT_DEFINED, "service '{0}' is not defined!",
            Error.CONTAINER_SERVICE_ALREADY_DEFINED, "service '{0}' was already defined!"

        };
    }
}
