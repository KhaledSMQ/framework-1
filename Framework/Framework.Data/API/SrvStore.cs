// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model.Config;
using Framework.Data.Model.Mem;
using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // Service dependencies.
        //

        protected IConfig SrvConfig { get; set; }

        protected IMem SrvMemStore { get; set; }

        protected IDAL SrvDAL { get; set; }

        protected ITransform SrvTransform { get; set; }

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

            SrvConfig = Scope.Hub.GetUnique<IConfig>();
            SrvMemStore = Scope.Hub.GetUnique<IMem>();
            SrvDAL = Scope.Hub.GetUnique<IDAL>();
            SrvTransform = Scope.Hub.GetUnique<ITransform>();
        }

        //
        // Load configuration values from the configuration store.
        // Load all settings, but also the data domains defined.
        //

        public void LoadConfiguration()
        {
            //
            // Load from the system configuration spec
            // the data store elements, domains and settings.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Load the configuration clusters from config store 
            // and load them into the runtime store service.
            //

            if (null != config)
            {
                config.Domains.Map<DomainElement, FW_DataDomain>(new List<FW_DataDomain>(), SrvTransform.Convert).Apply(SrvMemStore.Domain_Import);
            }
        }

        //
        // Initialize all domains. 
        // Initialize all loaded, (i.e. in memory) domains.
        //

        public void InitAllLoadedDomains()
        {
            SrvMemStore.Domain_GetList().Apply(SrvMemStore.Domain_Init);
        }

        //
        // DATA-ACCESS-LAYER
        //

        public object DAL_Create(string entityID, object value)
        {
            IProviderDataContext provider = SrvMemStore.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMemStore.Entity_Get(entityID);
            return SrvDAL.Create(provider, entity, value);
        }

        public object DAL_Query(string entityID, string name, object args)
        {
            IProviderDataContext provider = SrvMemStore.Entity_GetProviderDataContext(entityID);
            MemQuery query = SrvMemStore.Query_Get(entityID, name);
            MemEntity entity = SrvMemStore.Entity_Get(entityID);
            return SrvDAL.Query(provider, query, entity, args);
        }

        public object DAL_Update(string entityID, object value)
        {
            IProviderDataContext provider = SrvMemStore.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMemStore.Entity_Get(entityID);
            return SrvDAL.Update(provider, entity, value);
        }

        public object DAL_Delete(string entityID, object value)
        {
            IProviderDataContext provider = SrvMemStore.Entity_GetProviderDataContext(entityID);
            MemEntity entity = SrvMemStore.Entity_Get(entityID);
            return SrvDAL.Delete(provider, entity, value);
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        public object Mem_Dump()
        {
            return new {
                Domains = Mem_GetDomains(),
                Clusters = Mem_GetClusters(),
                Contexts = Mem_GetContexts(),
                Entities = Mem_GetEntities(),
                Models = Mem_GetModels(),
                Queries = Mem_GetQueries()
            };
        }

        public object Mem_GetDomains()
        {
            return SrvMemStore.Domain_GetList();
        }

        public object Mem_GetClusters()
        {
            return SrvMemStore.Cluster_GetList();
        }

        public object Mem_GetContexts()
        {
            return SrvMemStore.Context_GetList();
        }

        public object Mem_GetEntities()
        {
            return SrvMemStore.Entity_GetList();
        }

        public object Mem_GetModels()
        {
            return SrvMemStore.Model_GetList();
        }

        public object Mem_GetQueries()
        {
            return SrvMemStore.Query_GetList();
        }
    }
}
