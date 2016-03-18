// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model.Mem;
using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface IMemStore : ICommon
    { 
        //
        // DOMAIN
        //    

        void Domain_Import(DataDomain domain);

        void Domain_Init(string domainID);

        void Domain_Init(DomainInfo domain);

        DomainInfo Domain_Get(params string[] parcels);

        IEnumerable<DomainInfo> Domain_GetList();

        //
        // CLUSTER
        //

        string Cluster_Import(string domainID, DataCluster cluster);

        ClusterInfo Cluster_Get(params string[] parcels);

        IEnumerable<ClusterInfo> Cluster_GetList();

        //
        // CONTEXT
        //

        string Context_Import(string clusterID, DataContext context);

        ContextInfo Context_Get(params string[] parcels);

        IEnumerable<ContextInfo> Context_GetList();

        //
        // ENTITY
        //

        string Entity_Import(string clusterID, DataEntity entity);

        EntityInfo Entity_Get(params string[] parcels);

        Type Entity_GetType(params string[] parcels);

        IEnumerable<EntityInfo> Entity_GetList();

        IProviderDataContext Entity_GetProviderDataContext(params string[] parcels);

        //
        // PARTIAL-MODEL
        //

        string Model_Import(string clusterID, DataPartialModel model);

        ModelInfo Model_Get(params string[] parcels);

        IEnumerable<ModelInfo> Model_GetList();

        //
        // QUERY
        //

        string Query_Import(string entityID, DataQuery query);

        QueryInfo Query_Get(params string[] parcels);

        IEnumerable<QueryInfo> Query_GetList();

        //
        // IDENTIFIERS
        //

        string GetID(params string[] parcels);
    }
}
