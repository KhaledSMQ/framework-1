// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 31/May/2016
// Company: Cybermap Lta.
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

        public IEnumerable<FW_DataCluster> GetListOfClusters()
        {
            IEnumerable<FW_DataCluster> lstOfItems = null;

            //
            // Load the configuration clusters from config store 
            // and load them into the runtime store service.
            //

            if (null != Config)
            {
                lstOfItems = Config.Clusters.Map<ClusterElement, FW_DataCluster>(new List<FW_DataCluster>(), Scope.Hub.Get<ITransform>().Convert);
            }

            return lstOfItems;
        }
    }
}
