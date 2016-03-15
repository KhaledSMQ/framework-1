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
using System.Collections.Generic;

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

        void Add(DataCluster cluster);

        void Init(DataCluster cluster);

        DataCluster GetCluster(string name);

        IEnumerable<DataCluster> GetListOfClusters();

        //
        // ENTITIES
        //

        DataEntity GetEntity(string entityID);

        DataEntity GetEntity(string cluster, string entity);

        Type GetEntityType(string entityID);

        Type GetEntityType(string cluster, string entity);

        IProviderDataContext GetEntityDataProviderContext(string fullname);

        IProviderDataContext GetEntityDataProviderContext(string cluster, string entity);
    }
}
