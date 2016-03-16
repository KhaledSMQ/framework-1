// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.API;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;
using System;
using Framework.Data.Config;
using Framework.Data.Model;
using Framework.Core.Extensions;

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
            // the data store elements.
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
        // Initialize all loaded, (i.e. memory) domains.
        //

        public void InitAllLoadedDomains()
        {
            srvMemStore.GetListOfDomains().Apply(srvMemStore.InitDomain);
        }
    }
}
