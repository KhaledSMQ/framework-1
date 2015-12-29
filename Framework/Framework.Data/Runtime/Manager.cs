// ============================================================================
// Project: Framework
// Name/Class: Manager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime data store implementation.
// ============================================================================

using Framework.Data.Config;
using Framework.Data.Model;
using Owin;

namespace Framework.Data.Runtime
{
    public static class Manager
    {
        //
        // The runtime store where all data 
        // related specification is stored.
        //

        public static DataStore Store { get; private set; }

        //
        // CONSTRUCTORS
        //

        static Manager() { }

        //
        // Initialize the data manager services.
        // 

        public static void Init(IAppBuilder app)
        {
            LoadConfig();
        }

        //
        // Load the initial configuration for the data manager.
        //

        public static void LoadConfig()
        {
            //
            // Initialize the data store placeholder.
            //

            if (null == Store)
            {
                Store = new DataStore();
            }

            //
            // Load from the system configuration spec
            // the data store elements.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Add to store.
            //

            Store.Clusters = Transforms.ToDataCluster(config.Clusters);
        }
    }
}
