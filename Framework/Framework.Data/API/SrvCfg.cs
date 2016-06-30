// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 31/May/2016
// Company: Coop4Creativity
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public class SrvCfg : ACommon, ICfg
    {
        //
        // Internal state.
        //

        protected ConfigManager Config;

        //
        // Load configuration.
        //

        public void Load()
        {
            //
            // Load from the system configuration spec
            // the data store elements, domains and settings.
            //

            Config = (ConfigManager)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);
        }

        //
        // Return the list of domains defined in the configuration section.
        // 

        public IEnumerable<ConfigCluster> GetListOfClusters()
        {
            IEnumerable<ConfigCluster> lstOfItems = null;

            //
            // Load the configuration clusters from config store 
            // and load them into the runtime store service.
            //

            if (null != Config)
            {
                lstOfItems = Config.Clusters.Map<ConfigCluster, ConfigCluster>(new List<ConfigCluster>(), x => { return x; });
            }

            return lstOfItems;
        }
    }
}
