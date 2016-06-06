// ============================================================================
// Project: Framework
// Name/Class: IMemStore
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
    public interface IMem : ICommon
    {
        //
        // CLUSTER
        //

        void Cluster_Import(IEnumerable<FW_DataCluster> clusters);

        void Cluster_Import(FW_DataCluster cluster);

        void Cluster_Init(string clusterID);

        void Cluster_Init(IEnumerable<MemCluster> clusters);

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
