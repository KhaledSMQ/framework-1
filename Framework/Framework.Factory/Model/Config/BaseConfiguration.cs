// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Factory.Model.Config
{
    public class BaseElement : ConfigurationElement
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

    public class BaseElementWithType : BaseElement
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

    public class BaseElementWithSettings : BaseElement
    {
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

    public class BaseElementWithTypeAndSettings : BaseElementWithType
    {
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
