// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Packages.API
{
    public class SrvBundles : ACommon, IBundles
    {
        //
        // Get the bundle content.
        //

        public string GetBundleContent(string names, string mimeType, TypeOfContentFormat minify, object ctx)
        {
            string content = string.Empty;
            return content;
        }
    }
}
