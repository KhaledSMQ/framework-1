// ============================================================================
// Project: Framework
// Name/Class: UrlHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 31/Jul/2015
// Company: Coop4Creativity
// Description: Helper functions for urls.
// ============================================================================  

using System.IO;
using System.Net;

namespace Framework.Core.Helpers
{
    public static class UrlHelper
    {
        //
        // Read an url and get the result as a string.
        //

        public static string GetContentAsString(string fileUrl)
        {
            WebClient client = new WebClient();
            return new StreamReader(client.OpenRead(fileUrl)).ReadToEnd();
        }

        //
        // Check if a url is valid.
        //

        public static bool CheckIfValid(string uri, int timeOut = 5)
        {
            try
            {
                // 
                // Creating the HttpWebRequest
                //

                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

                // 
                // Setting the Request method HEAD.
                //

                request.Method = "HEAD";
                request.Timeout = timeOut * 1000;

                // 
                // Getting the Web Response.
                //

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                // 
                // Returns TRUE if the Status code == 200
                //

                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //
                // Any exception will return false.
                //

                return false;
            }
        }
    }
}
