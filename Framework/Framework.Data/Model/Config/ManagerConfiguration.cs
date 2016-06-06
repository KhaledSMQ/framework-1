// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ManagerConfiguration : ConfigurationSection
    {
        //
        // CLUSTERS
        //

        [ConfigurationProperty(Constants.CLUSTERS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ClusterElementCollection))]
        public ClusterElementCollection Clusters
        {
            get { return (ClusterElementCollection)this[Constants.CLUSTERS]; }
        }

        //
        // SETTINGS
        //

        [ConfigurationProperty(Constants.SETTINGS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SettingElementCollection))]
        public SettingElementCollection Settings
        {
            get { return (SettingElementCollection)this[Constants.SETTINGS]; }
        }
    }
}
