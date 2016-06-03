// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Packages.API
{
    public interface IMinifier : ICommon
    {
        //
        // Method to minify the content. Whatever that might be.
        //

        string Minify(string content);
    }
}
