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

        void Domain_Import(FW_DataDomain domain);

        void Domain_Init(string domainID);

        void Domain_Init(MemDomain domain);

        MemDomain Domain_Get(params string[] parcels);

        IEnumerable<MemDomain> Domain_GetList();

        //
        // CLUSTER
        //

        string Cluster_Import(string domainID, FW_DataCluster cluster);

        MemCluster Cluster_Get(params string[] parcels);

        IEnumerable<MemCluster> Cluster_GetList();

        //
        // CONTEXT
        //

        string Context_Import(string clusterID, FW_DataContext context);

        MemContext Context_Get(params string[] parcels);

        IEnumerable<MemContext> Context_GetList();

        //
        // ENTITY
        //

        string Entity_Import(string clusterID, FW_DataEntity entity);

        MemEntity Entity_Get(params string[] parcels);

        Type Entity_GetType(params string[] parcels);

        IEnumerable<MemEntity> Entity_GetList();

        IProviderDataContext Entity_GetProviderDataContext(params string[] parcels);

        //
        // PARTIAL-MODEL
        //

        string Model_Import(string clusterID, FW_DataPartialModel model);

        MemModel Model_Get(params string[] parcels);

        IEnumerable<MemModel> Model_GetList();

        //
        // QUERY
        //

        string Query_Import(string entityID, FW_DataQuery query);

        MemQuery Query_Get(params string[] parcels);

        IEnumerable<MemQuery> Query_GetList();

        //
        // IDENTIFIERS
        //

        string GetID(params string[] parcels);
    }
}
