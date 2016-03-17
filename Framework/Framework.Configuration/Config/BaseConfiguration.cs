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

        [ConfigurationProperty(_Const.NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[_Const.NAME]; }
            set { this[_Const.NAME] = value; }
        }

        //
        // DESCRIPTION
        //

        [ConfigurationProperty(_Const.DESCRIPTION, DefaultValue = "", IsRequired = false)]
        public string Description
        {
            get { return (string)this[_Const.DESCRIPTION]; }
            set { this[_Const.DESCRIPTION] = value; }
        }  
    }
}
