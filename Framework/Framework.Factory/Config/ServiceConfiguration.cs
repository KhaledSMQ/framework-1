// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Factory.Config
{
    public class ServiceElement : BaseElementWithTypeAndSettings
    { 
        //
        // CONTRACT
        //

        [ConfigurationProperty(Constants.CONTRACT, DefaultValue = "", IsRequired = true)]
        public string Contract
        {
            get { return (string)this[Constants.CONTRACT]; }
            set { this[Constants.CONTRACT] = value; }
        }
    }
}
