// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class LibConfiguration : Configuration.Model.Config.ModuleConfiguration
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
