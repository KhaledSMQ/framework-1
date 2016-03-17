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
                config.Domains.Map<DomainElement, DataDomain>(new List<DataDomain>(), Transforms.Converter).Apply(srvMemStore.LoadDomain);
            }
        }

        //
        // Initialize all domains. 
        // Initialize all loaded, (i.e. in memory) domains.
        //

        public void InitAllLoadedDomains()
        {
            srvMemStore.GetListOfDomains().Apply(srvMemStore.InitDomain);
        }

        //
        // ENTITIES
        // Data Access Layer for Entities.
        //

        public object Entity_Create(string entityID, object value)
        {
            Type type = srvMemStore.GetEntityType(entityID);
            object item = value;

            //
            // If value is a string, then we assume
            // that is an object in JSON fprmat.
            //

            if (value.GetType() == typeof(string))
            {
                item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, (string)value);
            }
            
            return null;
        }

        public object Entity_Query(string entityID, string name, object[] args)
        {
            throw new NotImplementedException();
        }

        public object Entity_Update(string entityID, object value)
        {
            Type type = srvMemStore.GetEntityType(entityID);
            object item = value;

            //
            // If value is a string, then we assume
            // that is an object in JSON fprmat.
            //

            if (value.GetType() == typeof(string))
            {
                item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, (string)value);
            }

            return null;
        }

        public object Entity_Delete(string entityID, object value)
        {
            Type type = srvMemStore.GetEntityType(entityID);
            object item = value;

            //
            // If value is a string, then we assume
            // that is an object in JSON fprmat.
            //

            if (value.GetType() == typeof(string))
            {
                item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, (string)value);
            }

            return null;
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        public object Mem_GetDomains()
        {
            return srvMemStore.GetListOfMemDomains();
        }

        public object Mem_GetContexts()
        {
            return srvMemStore.GetListOfMemContexts();
        }

        public object Mem_GetEntities()
        {
            return srvMemStore.GetListOfMemEntities();
        }
    }
}
