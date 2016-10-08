// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Core.Config
{
    public class ModuleConfiguration : ConfigurationSection
    {
        //
        // MODULE SERVICES
        //

        [ConfigurationProperty(Constants.SERVICES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceElementCollection))]
        public ServiceElementCollection Services
        {
            get { return (ServiceElementCollection)this[Constants.SERVICES]; }
        }
    }
}
