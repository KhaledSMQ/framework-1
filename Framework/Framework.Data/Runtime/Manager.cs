// ============================================================================
// Project: Framework
// Name/Class: Manager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime data store implementation.
// ============================================================================

using Framework.Data.Model;

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

        public static void Init()
        {
            LoadConfig();
        }

        //
        // Load the initial configuration for the data manager.
        //

        public static void LoadConfig()
        {

        }
    }
}
