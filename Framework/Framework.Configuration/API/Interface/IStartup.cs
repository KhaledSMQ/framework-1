// ============================================================================
// Project: Framework
// Name/Class: IStartup
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Startup service contract.
// ============================================================================

using Framework.Factory.Patterns;
using Owin;

namespace Framework.Configuration.API.Interface
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
