// ============================================================================
// Project: Framework
// Name/Class: PathHelper
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Set of extension methods for web apps paths.
// ============================================================================                    

using Framework.Core.Extensions;
using System.Web;

namespace Framework.Core.Helpers
{
    public static class PathHelper
    {
        public static string ApplicationPath()
        {
            return ApplicationPath(HttpContext.Current);
        }

        public static string ApplicationPath(HttpContext context)
        {
            string output = string.Empty;

            if (null != context)
            {
                // 
                // Formatting the fully qualified website url/name.
                //

                output = string.Format("{0}://{1}{2}{3}", context.Request.Url.Scheme, context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port, context.Request.ApplicationPath);
            }

            if (!output.EndsWith("/"))
            {
                output += "/";
            }

            return output;
        }

        public static string HostPath()
        {
            return HostPath(HttpContext.Current);
        }

        public static string HostPath(HttpContext context)
        {
            string output = string.Empty;

            if (null != context)
            {
                // 
                // Formatting the fully qualified website url/name.
                //

                output = string.Format("{0}://{1}{2}", context.Request.Url.Scheme, context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port);
            }

            if (!output.EndsWith("/"))
            {
                output += "/";
            }

            return output;
        }

        public static string HostPathNoProtocol()
        {
            return HostPathNoProtocol(HttpContext.Current);
        }

        public static string HostPathNoProtocol(HttpContext context)
        {
            string output = string.Empty;

            if (null != context)
            {
                // 
                // Formatting the fully qualified website url/name.
                //

                output = string.Format("{0}{1}", context.Request.Url.Host, context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port);
            }

            if (output.EndsWith("/"))
            {
                output = output.ChopEnd(1);
            }

            return output;
        }
    }
}
