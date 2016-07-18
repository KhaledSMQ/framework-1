// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Collections.Generic;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Web.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Web.API
{
    public class SrvResolver : ACommon, IResolver
    {
        //
        // PROPERTIES
        //

        public string HostPath { get { return __GetHostPath(); } }

        public string ApplicationPath { get { return __GetApplicationPath(); } }       
      
        //
        // Resolve a relative url.
        //

        public string ResolveUrl(string relUrl)
        {
            return ResolveWithBaseUrl(ApplicationPath, relUrl);
        }

        public string ResolveUrlWithParams(string relUrl, params object[] values)
        {
            return ResolveUrl(relUrl + BuildQueryString(values));
        }

        //
        // Resolve a relative url with a base url.
        //

        public string ResolveWithBaseUrl(string baseUrl, string relUrl)
        {
            string resolved = string.Empty;

            if (!string.IsNullOrEmpty(relUrl))
            {
                resolved = relUrl.ResolveUrl(baseUrl);
            }

            return resolved;
        }

        public string ResolveWithBaseUrlAndParams(string baseUrl, string relUrl, params object[] values)
        {
            return ResolveWithBaseUrl(baseUrl, relUrl + BuildQueryString(values));
        }
   
        //
        // Take a list of objects and return the query string with these objects.
        // Pairs of name and value. name is a string, value is an object.
        //

        public string BuildQueryString(params object[] values)
        {
            StringBuilder qsBuilder = new StringBuilder(string.Empty);

            if ((null != values) && (values.Length > 0))
            {
                qsBuilder.Append('?');

                for (int i = 0; i < values.Length; )
                {
                    string paramName = values[i].ToString();
                    string paramVal = string.Empty;

                    //
                    // try to get the parameter value.
                    //

                    i++;

                    if (i < values.Length)
                    {
                        paramVal = values[i].ToString();

                        qsBuilder.Append(paramName);
                        qsBuilder.Append('=');
                        qsBuilder.Append(paramVal);

                        //
                        // Move to next parameter.
                        //

                        i++;

                        //
                        // Check if we should add the & separator.
                        //

                        if (i < values.Length)
                        {
                            qsBuilder.Append('&');
                        }
                    }
                }
            }

            return qsBuilder.ToString();
        }

        //
        // Take a variable list of lists that contain pairs of
        // para parameters (name/value). Return a merged list
        // of parameters.
        //

        public object[] MergeListOfParams(params object[][] values)
        {
            IList<object> output = new List<object>();

            IDictionary<string, object> mapMerged = new DictOrdered<string, object>();

            foreach (object[] currList in values)
            {
                for (int i = 0; i + 1 < currList.Length; i += 2)
                {
                    string name = currList[i].ToString();
                    object value = currList[i + 1];

                    if (mapMerged.ContainsKey(name))
                    {
                        mapMerged[name] = value;
                    }
                    else
                    {
                        mapMerged.Add(name, value);
                    }
                }
            }

            mapMerged.Keys.Apply(key =>
            {
                output.Add(key);
                output.Add(mapMerged[key]);
            });

            return output.ToArray();
        }

        public object[] MergeParams(object[] leftSide, params object[] additional)
        {
            return MergeListOfParams(leftSide, additional);
        }

        //
        // Get the host path.
        //

        private string __GetHostPath()
        {
            return PageExtensions.HostPath();
        }

        private string __GetApplicationPath()
        {
            return PageExtensions.ApplicationPath();
        }
    }
}
