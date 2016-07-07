// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
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
