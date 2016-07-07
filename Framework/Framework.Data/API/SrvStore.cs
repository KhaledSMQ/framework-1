// ============================================================================
// Project: Framework
// Name/Class: SrvStore
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Data store service implementation.
// ============================================================================

using Framework.Data.Model.Config;
using Framework.Data.Model.Import;
using Framework.Data.Model.Mem;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using Framework.Core.Extensions;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // Service dependencies.
        //

        protected ICfg SrvCfg { get; set; }

        protected IMem SrvMem { get; set; }

        protected IDAL SrvDAL { get; set; }

        //
        // Service initialization. 
        // Boot the dependant services.
        //

        public override void Init()
        {
            //
            // Initialize base service infrastructure.
            //

            base.Init();

            //
            // Initialize dependent services.
            // NOTE: We do this here because all these services
            // do not have dependencies that are circular to this service.
            //

            SrvCfg = Scope.Hub.GetUnique<ICfg>();
            SrvMem = Scope.Hub.GetUnique<IMem>();
            SrvDAL = Scope.Hub.GetUnique<IDAL>();           
        }

        //
        // SCHEMA-ACCESS-LAYER
        //

        public void Schema_Load()
        {
            SrvCfg.Load();
        }

        public void Schema_Init()
        {
            SrvMem.Cluster_Init(SrvMem.Cluster_GetList());
        }

        public void Schema_Init(string cluster)
        {
            SrvMem.Cluster_Init(cluster);
        }

        public void Schema_Import(IEnumerable<ImportCluster> clusters)
        {
            clusters.Apply(Schema_Import);
        }

        public void Schema_Import(ImportCluster cluster)
        {
            SrvMem.Cluster_Import(Scope.Hub.Get<ITransform>().Convert(cluster));
        }    

        //
        // DATA-ACCESS-LAYER
        //

        public object Dal_Create(string entityID, object value)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Create(provider, entity, value);
        }

        public object Dal_Query(string entityID, string name, object args)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemQuery query = SrvMem.Query_Get(entityID, name);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Query(provider, query, entity, args);
        }

        public object Dal_Update(string entityID, object value)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Update(provider, entity, value);
        }

        public object Dal_Delete(string entityID, object value)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Delete(provider, entity, value);
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        public object Mem_Dump()
        {
            return new {
                Clusters = Mem_GetClusters(),
                Contexts = Mem_GetContexts(),
                Entities = Mem_GetEntities(),
                Models = Mem_GetModels(),
                Queries = Mem_GetQueries()
            };
        }

        public object Mem_GetClusters()
        {
            return SrvMem.Cluster_GetList();
        }

        public object Mem_GetContexts()
        {
            return SrvMem.Context_GetList();
        }

        public object Mem_GetEntities()
        {
            return SrvMem.Entity_GetList();
        }

        public object Mem_GetModels()
        {
            return SrvMem.Model_GetList();
        }

        public object Mem_GetQueries()
        {
            return SrvMem.Query_GetList();
        }
    }
}
