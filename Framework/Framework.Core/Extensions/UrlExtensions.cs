// ============================================================================
// Project: Toolkit
// Name/Class: UrlExtensions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 29/July/2013
// Company: Coop4Creativity
// Description: String extensions for Web related functions.
// ============================================================================

using Framework.Core.Helpers;
using System;
using System.Text;
using System.Web;

namespace Framework.Core.Extensions
{
    //
    // String extensions methods
    // Extend string datatypes with additional methods, the methods
    // found in this class are for web development
    //

    public static class UrlExtensions
    {
        //
        // Check if a certain string is a valid uri
        // Valid uris are absolute uris and relative uris
        // Returns true if the string is a valid absolute/relative uri, false otherwise.
        //

        public static bool IsUri(this string uri)
        {
            string encoded = uri.EncodeUrl();
            if (!string.IsNullOrEmpty(uri) && Uri.IsWellFormedUriString(encoded, UriKind.RelativeOrAbsolute))
            {
                Uri tempValue;
                return (Uri.TryCreate(encoded, UriKind.RelativeOrAbsolute, out tempValue));
            }
            return false;
        }

        //
        // Get the absolute path. If the path is alreay absolute, just 
        // return it, otherwise attachs the current server location and
        // host header
        //

        public static string AbsoluteUrl(this string url)
        {
            return url.AbsoluteUri();
        }

        public static string AbsoluteUri(this string uri)
        {
            string trimmedUrl = uri.TrimStart();
            string absUrl = trimmedUrl;

            // 
            // Only apply this if url starts with / or ~/
            //

            if (trimmedUrl.StartsWith("~"))
            {
                string appPath = PathHelper.ApplicationPath();
                string resolvedUrl = trimmedUrl.ResolveUrl(appPath);
                absUrl = resolvedUrl;
            }
            else
                if (trimmedUrl.StartsWith("/"))
                {
                    string resolvedUrl = trimmedUrl.ChopStart(1);
                    absUrl = PathHelper.HostPath() + resolvedUrl;
                }

            return absUrl;
        }

        //
        // Resolve the Url. 
        // TODO: Dont know why this default to HttpRuntime.AppDomainAppVirtualPath..
        // it should default to the application path.
        //

        public static string ResolveUrl(this string relativeUrl)
        {
            return relativeUrl.ResolveUrl(HttpRuntime.AppDomainAppVirtualPath);
        }

        //
        // Resolve Url, taking the current relative url and a base url.
        // This method should return the absolute path for the supplied url.
        //

        public static string ResolveUrl(this string relativeUrl, string baseUrl)
        {
            //
            // If supplied url is empty, then this method call does not make
            // any sense. throw an error.
            //

            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' || relativeUrl[0] == '\\')
            {
                return relativeUrl;
            }

            int idxOfScheme = relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(baseUrl);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/')
            {
                sbUrl.Append('/');
            }

            //
            // Found question mark already? query string, do not touch!
            //

            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1 && relativeUrl[0] == '~' && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else
            {
                foundSlash = false;
            }

            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash)
                            {
                                continue;
                            }
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else
                            if (foundSlash)
                            {
                                foundSlash = false;
                            }
                    }
                }

                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }

        //
        // Return the virtual path from the full server path.
        // 

        public static string GetVirtualPath(this string fullServerPath)
        {
            return @"~\" + fullServerPath.Replace(HttpContext.Current.Request.PhysicalApplicationPath, String.Empty);
        }

        //
        // Encode the string in HTML
        //

        public static string EncodeHTML(this string s)
        {
            return System.Web.HttpUtility.HtmlEncode(s);
        }

        // 
        // Decode the string from HTML
        // 

        public static string DecodeHTML(this string s)
        {
            return System.Web.HttpUtility.HtmlDecode(s);
        }

        // 
        // Encode an url
        // Transforms invalid urls into valid encoded urls, takes
        // the human readable format and generates a valid url
        //

        public static string EncodeUrl(this string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        //
        // Decode an url
        // Transforms and encoded url to a human readable format
        //

        public static string DecodeUrl(this string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        //
        // Combine two Urls into one.
        // TODO: Test this.. not foul proof...
        //

        public static string CombineUrlSegments(params string[] parts)
        {
            string combinedUrl = string.Empty;

            if (null != parts && parts.Length > 0)
            {
                var urlBuilder = new StringBuilder();

                foreach (var part in parts)
                {
                    var tempUrl = _TryCreateRelativeOrAbsolute(part);
                    urlBuilder.Append(tempUrl);
                }

                combinedUrl = VirtualPathUtility.RemoveTrailingSlash(urlBuilder.ToString());
            }

            return combinedUrl;
        }

        private static string _TryCreateRelativeOrAbsolute(string s)
        {
            System.Uri uri;
            Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out uri);
            string tempUrl = VirtualPathUtility.AppendTrailingSlash(uri.ToString());
            return tempUrl;
        }
    }
}