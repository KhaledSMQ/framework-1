// ============================================================================
// Project: Framework
// Name/Class: SrvStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data store service implementation.
// ============================================================================

using Framework.Data.Model.Mem;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;

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
        // Load configuration values from the configuration store.
        // Load all settings, but also the data domains defined.
        //

        public void Boot()
        {
            SrvCfg.Load();
            SrvMem.Cluster_Import(SrvCfg.GetListOfClusters());
        }

        //
        // Initialize all domains. 
        // Initialize all loaded, (i.e. in memory) domains.
        //

        public void Setup()
        {
            SrvMem.Cluster_Init(SrvMem.Cluster_GetList());
        }

        //
        // DATA-ACCESS-LAYER
        //

        public object DAL_Create(string entityID, object value)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Create(provider, entity, value);
        }

        public object DAL_Query(string entityID, string name, object args)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemQuery query = SrvMem.Query_Get(entityID, name);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Query(provider, query, entity, args);
        }

        public object DAL_Update(string entityID, object value)
        {
            IProviderDataContext provider = SrvMem.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMem.Entity_Get(entityID);
            return SrvDAL.Update(provider, entity, value);
        }

        public object DAL_Delete(string entityID, object value)
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
