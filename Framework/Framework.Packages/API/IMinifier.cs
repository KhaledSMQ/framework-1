// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Api;

namespace Framework.Packages.Api
{
    public interface IMinifier : ICommon
    {
        //
        // Method to minify the content. Whatever that might be.
        //

        string Minify(string content);
    }
}
