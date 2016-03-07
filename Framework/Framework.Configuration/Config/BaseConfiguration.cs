// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Configuration.Config
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
}
