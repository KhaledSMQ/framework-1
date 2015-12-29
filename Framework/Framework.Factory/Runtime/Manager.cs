// ============================================================================
// Project: Framework
// Name/Class: MAnager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime context implementation.
// ============================================================================

using Framework.Factory.API.Interface;
using Framework.Factory.Config;
using Framework.Factory.Model;
using Owin;

namespace Framework.Factory.Runtime
{
    public static class Manager
    {
        //
        // PROPERTIES
        //

        public static Service HubConfig { get; private set; }

        public static Service ScopeConfig { get; private set; }

        public static IHub Hub { get; private set; }

        //
        // CONSTRUCTORS
        //

        static Manager() { }

        public static IScope Get()
        {
            return null;

            /*
            IScope scope = Hub.Get<IScope>();
            return scope;
            */
        }

        //
        // Initialize the data manager services.
        // 

        public static void Init(IAppBuilder app)
        {
            LoadConfig();
        }

        //
        // Load the initial configuration for factory library.
        //

        public static void LoadConfig()
        {
            //
            // Load from the system configuration.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Transform it.
            //

            HubConfig = Transforms.ToService(config.Hub);
            ScopeConfig = Transforms.ToService(config.Scope);
        }
    }
}
