// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 31/May/2016
// Company: Cybermap Lta.
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public class SrvConfig : ACommon, IConfig
    {
        //
        // Internal state.
        //

        protected ManagerConfiguration Config;

        //
        // Load configuration.
        //

        public void Load()
        {
            //
            // Load from the system configuration spec
            // the data store elements, domains and settings.
            //

            Config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);
        }

        //
        // Return the list of domains defined in the configuration section.
        // 

        public IEnumerable<FW_DataDomain> GetListOfDomains()
        {
            IEnumerable<FW_DataDomain> lstOfDomains = null;

            //
            // Load the configuration clusters from config store 
            // and load them into the runtime store service.
            //

            if (null != Config)
            {
                lstOfDomains = Config.Domains.Map<DomainElement, FW_DataDomain>(new List<FW_DataDomain>(), Scope.Hub.Get<ITransform>().Convert);
            }

            return lstOfDomains;
        }
    }
}
