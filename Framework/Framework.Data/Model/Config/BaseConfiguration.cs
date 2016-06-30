// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigBase : ConfigurationElement
    { 
        //
        // NAME
        //

        [ConfigurationProperty(Constants.NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[Constants.NAME]; }
            set { this[Constants.NAME] = value; }
        }

        //
        // DESCRIPTION
        //

        [ConfigurationProperty(Constants.DESCRIPTION, DefaultValue = "", IsRequired = false)]
        public string Description
        {
            get { return (string)this[Constants.DESCRIPTION]; }
            set { this[Constants.DESCRIPTION] = value; }
        }  
    }

    public class ConfigBaseWithType : ConfigBase
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
    }

    public class ConfigBaseWithSettings : ConfigBase
    {
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

    public class ConfigBaseWithTypeAndSettings : ConfigBaseWithType
    {
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
