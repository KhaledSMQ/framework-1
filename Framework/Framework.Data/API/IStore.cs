// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model.Config;
using Framework.Data.Model.Import;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface IStore : ICommon
    {
        //
        // SCHEMA-ACCESS-LAYER
        //

        void Schema_Load();

        void Schema_Init();

        void Schema_Init(string cluster);

        void Schema_Import(IEnumerable<ImportCluster> clusters);

        void Schema_Import(ImportCluster cluster);

        void Schema_Import(IEnumerable<ConfigCluster> clusters);

        void Schema_Import(ConfigCluster cluster);

        //
        // DATA-ACCESS-LAYER
        //

        object Dal_Create(string entity, object value);

        object Dal_Query(string entity, string name, object args);

        object Dal_Update(string entity, object value);

        object Dal_Delete(string entity, object value);

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        object Mem_Dump();

        object Mem_GetClusters();

        object Mem_GetContexts();

        object Mem_GetEntities();

        object Mem_GetModels();

        object Mem_GetQueries();
    }
}
