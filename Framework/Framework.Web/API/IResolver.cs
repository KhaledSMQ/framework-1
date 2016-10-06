// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Api;

namespace Framework.Web.Api
{
    public interface IResolver : ICommon
    {
        //
        // PROPERTIES
        //

        string HostPath { get; }

        string ApplicationPath { get; }            

        //
        // Resolve a relative url.
        //

        string ResolveUrl(string relUrl);

        string ResolveUrlWithParams(string relUrl, params object[] values);

        //
        // Resolve a relative url with a base url.
        //

        string ResolveWithBaseUrl(string baseUrl, string relUrl);

        string ResolveWithBaseUrlAndParams(string baseUrl, string relUrl, params object[] values);   

        //
        // Take a list of objects and return the query string with these objects.
        // Pairs of name and value. name is a string, value is an object.
        //

        string BuildQueryString(params object[] values);

        //
        // Take a variable list of lists that contain pairs of
        // para parameters (name/value). Return a merged list
        // of parameters.
        //

        object[] MergeListOfParams(params object[][] values);

        object[] MergeParams(object[] leftSide, params object[] additional);
    }
}
