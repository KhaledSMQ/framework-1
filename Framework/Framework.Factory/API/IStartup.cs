// ============================================================================
// Project: Framework
// Name/Class: IStartup
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Startup service contract.
// ============================================================================

using Framework.Factory.Patterns;
using Owin;

namespace Framework.Factory.API
{
    public interface IStartup : ICommon
    {
        //
        // Method to execute when application starts.
        // @param app The application reference object.
        //

        void Startup(IAppBuilder app);        
    }
}
