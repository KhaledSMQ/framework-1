// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;

namespace Framework.Data.API
{
    public interface IDataStore : ICommon
    {
        //
        // INIT
        //

        void InitClusters();      

        //
        // CLUSTERS
        //    

        void Load(DataCluster cluster);

        void Init(string clusterID);

        //
        // ENTITIES
        //

        DataEntity GetEntity(string entityID);

        DataEntity GetEntity(string cluster, string entity);

        Type GetEntityType(string entityID);

        Type GetEntityType(string cluster, string entity);

        IProviderDataContext GetEntityDataProviderContext(string entityID);

        IProviderDataContext GetEntityDataProviderContext(string cluster, string entity);
    }
}
