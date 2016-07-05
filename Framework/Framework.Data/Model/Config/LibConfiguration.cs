// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class LibConfiguration : ConfigurationSection
    {
        //
        // CLUSTERS
        //

        [ConfigurationProperty(Constants.CLUSTERS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigClusterCollection))]
        public ConfigClusterCollection Clusters
        {
            get { return (ConfigClusterCollection)this[Constants.CLUSTERS]; }
        }

        //
        // SETTINGS
        //

        [ConfigurationProperty(Constants.SETTINGS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigSettingCollection))]
        public ConfigSettingCollection Settings
        {
            get { return (ConfigSettingCollection)this[Constants.SETTINGS]; }
        }
    }
}
