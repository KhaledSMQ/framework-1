// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Factory.Config
{
    public class ManagerConfiguration : ConfigurationSection
    {
        //
        // HUB
        //

        [ConfigurationProperty(Constants.HUB)]
        public ServiceElement Hub
        {
            get { return (ServiceElement)this[Constants.HUB]; }
        }

        //
        // HUB
        //

        [ConfigurationProperty(Constants.ENTRY)]
        public ServiceElement Entry
        {
            get { return (ServiceElement)this[Constants.ENTRY]; }
        }

        //
        // SCOPE
        //

        [ConfigurationProperty(Constants.SCOPE)]
        public ServiceElement Scope
        {
            get { return (ServiceElement)this[Constants.SCOPE]; }
        }
    }
}
