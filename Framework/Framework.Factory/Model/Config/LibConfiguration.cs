// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Factory.Model.Config
{
    public class LibConfiguration : ConfigurationSection
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
        // CORE SERVICES
        //

        [ConfigurationProperty(Constants.SERVICES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceElementCollection))]
        public ServiceElementCollection Services
        {
            get { return (ServiceElementCollection)this[Constants.SERVICES]; }
        }
    }
}
