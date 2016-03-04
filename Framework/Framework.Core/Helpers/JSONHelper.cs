// ============================================================================
// Project: Framework
// Name/Class: JSONHelper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 23/Dez/2014
// Company: Cybermap Lta.
// Description: JSON Reader
// ============================================================================

using Framework.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Framework.Core.Helpers
{
    public static class JSONHelper
    {
        //
        // READ-JSON-OBJECT
        // Read and parse JSON object from strings and urls.
        //

        public static object ReadArbitraryJSONObject<T>(string url)
        {
            object output = default(object);

            //
            // Create the web request, set the header to accept
            // the JSON mime type.
            //

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = MimeTypeHelper.TYPE_JSON;

            //
            // Make the request.
            // Process answer.
            //

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //
                // Check if service call returned an error.
                // If so, end with exception.
                //

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("[{0}]:server error (HTTP {1}: {2}).", url, response.StatusCode, response.StatusDescription));
                }

                //
                // Transform stream into a string.
                // Read all bytes.
                //

                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string responseString = responseReader.ReadToEnd().TrimStart();

                //
                // Transform the string into actual objects.
                //

                if (responseString.StartsWith("{"))
                {
                    output = JToken.Parse(responseString).ToObject<T>();
                }
                else
                    if (responseString.StartsWith("["))
                    {
                        output = JArray.Parse(responseString).Map(new List<T>(), token => token.ToObject<T>());
                    }
                    else
                    {
                        throw new Exception(String.Format("[{0}]:Cannot read this JSON, sorry...", url));
                    }
            }

            return output;
        }

        public static object ReadArbitraryJSONObjectFromString<T>(string value)
        {
            object output = default(object);

            if (value.StartsWith("{"))
            {
                output = JToken.Parse(value).ToObject<T>();
            }
            else
                if (value.StartsWith("["))
                {
                    output = JArray.Parse(value).Map(new List<T>(), token => token.ToObject<T>());
                }
                else
                {
                    throw new Exception(String.Format("Cannot read this JSON '{0}'", value));
                }


            return output;
        }

        //
        // READ-LIST-OF-JSON-OBJECT
        // Read and parse list of JSON objects from strings and urls.
        //

        public static IList<T> ReadListOfJSONObjects<T>(string url)
        {
            IList<T> output = null;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //
                // Check if service call returned an error.
                // If so, end with exception.
                //

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("[{0}]:server error (HTTP {1}: {2}).", url, response.StatusCode, response.StatusDescription));
                }

                //
                // Transform stream into a string.
                // Read all bytes.
                //

                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string responseString = responseReader.ReadToEnd();

                JArray lstOfObjects = JArray.Parse(responseString);

                output = new List<T>();

                lstOfObjects.Apply<JToken>(token =>
                {
                    output.Add(token.ToObject<T>());
                });
            }

            return output;
        }

        public static IList<T> ReadListOfJSONObjectsFromString<T>(string value)
        {
            IList<T> output = null;

            JArray lstOfObjects = JArray.Parse(value);

            output = new List<T>();

            lstOfObjects.Apply<JToken>(token =>
            {
                output.Add(token.ToObject<T>());
            });

            return output;
        }

        //
        // READ-JSON-OBJECT
        // Read and parse JSON object from strings and urls.
        //

        public static T ReadJSONObject<T>(string url)
        {
            T output = default(T);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //
                // Check if service call returned an error.
                // If so, end with exception.
                //

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("[{0}]:server error (HTTP {1}: {2}).", url, response.StatusCode, response.StatusDescription));
                }

                //
                // Transform stream into a string.
                // Read all bytes.
                //

                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string responseString = responseReader.ReadToEnd();

                //
                // Get the object.
                //

                JToken obj = JToken.Parse(responseString);
                output = obj.ToObject<T>();
            }

            return output;
        }

        public static T ReadJSONObjectFromString<T>(string value)
        {
            T output = default(T);

            JToken obj = JToken.Parse(value);
            output = obj.ToObject<T>();

            return output;
        }

        // 
        // WRITE-JSON-OBJECT
        // Write to a string a CLR object.
        //

        public static string WriteJSONObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
