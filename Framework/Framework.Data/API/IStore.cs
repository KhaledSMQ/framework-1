// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface IStore : ICommon
    {
        //
        // Load configuration settings for the store.
        // This will load all settings but also the 
        // data domains that are defined on the configuration
        // store.
        //

        void LoadConfiguration();

        //
        // Initialize all memory loaded domains.
        // Method will only initialize domains that are loaded
        // but were not initialized, this means you can call this 
        // method multiple times.
        //

        void InitAllLoadedDomains();

        //
        // DATA-ACCESS-LAYER
        // Data Access Layer Entities.
        //

        object DAL_Create(string entityID, object value);

        object DAL_Query(string entityID, string name, object args);

        object DAL_Update(string entityID, object value);

        object DAL_Delete(string entityID, object value);

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        object Mem_Dump();

        object Mem_GetDomains();

        object Mem_GetClusters();

        object Mem_GetContexts();

        object Mem_GetEntities();

        object Mem_GetModels();

        object Mem_GetQueries();
    }
}
