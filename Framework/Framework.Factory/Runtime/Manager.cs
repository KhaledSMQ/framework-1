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
using Framework.Factory.Patterns;
using Owin;

namespace Framework.Factory.Runtime
{
    public static class Manager
    {
        //
        // PROPERTIES
        //

        public static ServiceEntry HubConfig { get; private set; }

        public static ServiceEntry EntryConfig { get; private set; }

        public static ServiceEntry ScopeConfig { get; private set; }

        public static IHub Hub { get { return __GetCoreService<IHub>(__Hub, HubConfig); } }

        public static IServiceEntry Entry { get { return __GetCoreService<IServiceEntry>(__Entry, EntryConfig); } }

        public static IScope Scope { get { return __GetCoreService<IScope>(__Scope, ScopeConfig); } }

        //
        // CONSTRUCTORS
        //

        static Manager() { }

        //
        // Initialize the data manager services.
        // 

        public static void Init(IAppBuilder app)
        {
            //
            // Load base configuration.
            //

            LoadConfig();

            //
            // Startup the service hub.
            //

            //
            // Initialize the service entry.
            //

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
            // Base services are now in memory.
            //

            HubConfig = Transforms.ToService(config.Hub);
            ScopeConfig = Transforms.ToService(config.Scope);
            EntryConfig = Transforms.ToService(config.Entry);
        }

        //
        // HELPERS for core services.
        //

        private static T __GetCoreService<T>(T memValue, ServiceEntry config) where T : ICommon
        {
            T output = default(T);

            if (null != memValue)
            {
                return memValue;
            }

            return output;
        }

        private static IHub __Hub = null;
        private static IServiceEntry __Entry = null;
        private static IScope __Scope = null;
    }
}
