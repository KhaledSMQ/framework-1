// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Config
{
    public class BaseElement : ConfigurationElement
    { 
        //
        // Name
        //

        [ConfigurationProperty(Property.NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[Property.NAME]; }
            set { this[Property.NAME] = value; }
        }

        //
        // Description
        //

        [ConfigurationProperty(Property.DESCRIPTION, DefaultValue = "", IsRequired = true)]
        public string Description
        {
            get { return (string)this[Property.DESCRIPTION]; }
            set { this[Property.DESCRIPTION] = value; }
        }

        //
        // Type Name
        //

        [ConfigurationProperty(Property.TYPE, DefaultValue = "", IsRequired = true)]
        public string Type
        {
            get { return (string)this[Property.TYPE]; }
            set { this[Property.TYPE] = value; }
        }
    }
}
