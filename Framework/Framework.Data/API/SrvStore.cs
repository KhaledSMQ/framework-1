// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System;
using Framework.Data.Patterns;
using Framework.Core.Error;
using System.Linq.Dynamic;
using Framework.Data.Model.Mem;

namespace Framework.Data.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // Service dependencies.
        //

        protected IMemStore srvMemStore { get; set; }

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

            srvMemStore = Scope.Hub.GetUnique<IMemStore>();
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
                config.Domains.Map<DomainElement, FW_DataDomain>(new List<FW_DataDomain>(), Transforms.Converter).Apply(srvMemStore.Domain_Import);
            }
        }

        //
        // Initialize all domains. 
        // Initialize all loaded, (i.e. in memory) domains.
        //

        public void InitAllLoadedDomains()
        {
            srvMemStore.Domain_GetList().Apply(srvMemStore.Domain_Init);
        }

        //
        // ENTITIES
        // Data Access Layer for Entities.
        //

        public object Entity_Create(string entityID, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __Entity_GetItem(entityID, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __Entity_GetDynamicDataSet(entityID);

            //
            // Create and save changes.
            //

            object output = dataSet.Create(item);
            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        public object Entity_Query(string entityID, string name, object args)
        {
            //
            // Get the query specification to run.
            //

            MemQuery query = srvMemStore.Query_Get(entityID, name);

            //
            // Process arguments.
            //

            if (args.GetType() == typeof(string))
            {

            }

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __Entity_GetDynamicDataSet(entityID);

            //
            // Run query.
            //

            object output = dataSet.Queryable().Where(query.Query);

            return output;
        }

        public object Entity_Update(string entityID, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __Entity_GetItem(entityID, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __Entity_GetDynamicDataSet(entityID);

            //
            // Create and save changes.
            //

            object output = dataSet.Update(item);
            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        public object Entity_Delete(string entityID, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __Entity_GetItem(entityID, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __Entity_GetDynamicDataSet(entityID);

            //
            // Create and save changes.
            //

            object output = dataSet.Delete(item);
            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        private object __Entity_GetItem(string entityID, object value)
        {
            Type type = srvMemStore.Entity_GetType(entityID);

            object item = value;

            //
            // If value is a string, then we assume
            // that is an object in JSON fprmat.
            //

            if (value.GetType() == typeof(string))
            {
                item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, (string)value);
            }

            return item;
        }

        private IProviderDataContext __Entity_GetProviderDataContext(string entityID)
        {
            //
            // Default return value for entity data set.
            //            

            IProviderDataContext provider = srvMemStore.Entity_GetProviderDataContext(entityID);

            if (null == provider)
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get data context provider for entity '{0}'!", entityID);
            }

            //
            // Return the infered data set for entity.
            //

            return provider;
        }

        private IDynamicDataSet __Entity_GetDynamicDataSet(string entityID)
        {
            //
            // Default return value for entity data set.
            //            

            IDynamicDataSet dataSet = null;

            IProviderDataContext provider = __Entity_GetProviderDataContext(entityID);

            Type type = srvMemStore.Entity_GetType(entityID);

            if (null != type)
            {
                dataSet = provider.GetDataSet(type);

                if (null == dataSet)
                {
                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get data set provider for entity '{0}'!", entityID);
                }
            }
            else
            {

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get type for entity '{0}'!", entityID);
            }

            //
            // Return the infered data set for entity.
            //

            return dataSet;
        }

        private IDynamicDataObject __Entity_GetDynamicDataObject(string entityID)
        {
            //
            // Default return value for entity data set.
            //            

            IDynamicDataObject dataObject = null;

            IProviderDataContext provider = __Entity_GetProviderDataContext(entityID);

            Type type = srvMemStore.Entity_GetType(entityID);

            if (null != type)
            {
                dataObject = provider.GetDataObject(type);

                if (null == dataObject)
                {
                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get data set provider for entity '{0}'!", entityID);
                }
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get type for entity '{0}'!", entityID);
            }

            //
            // Return the infered data set for entity.
            //

            return dataObject;
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
            return srvMemStore.Domain_GetList();
        }

        public object Mem_GetClusters()
        {
            return srvMemStore.Cluster_GetList();
        }

        public object Mem_GetContexts()
        {
            return srvMemStore.Context_GetList();
        }

        public object Mem_GetEntities()
        {
            return srvMemStore.Entity_GetList();
        }

        public object Mem_GetModels()
        {
            return srvMemStore.Model_GetList();
        }

        public object Mem_GetQueries()
        {
            return srvMemStore.Query_GetList();
        }
    }
}
