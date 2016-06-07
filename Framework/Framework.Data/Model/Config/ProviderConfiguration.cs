// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigProvider : ConfigurationElement
    {
        //
        // TYPE-NAME
        //

        [ConfigurationProperty(Constants.TYPE, DefaultValue = "", IsRequired = true)]
        public string Type
        {
            get { return (string)this[Constants.TYPE]; }
            set { this[Constants.TYPE] = value; }
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
