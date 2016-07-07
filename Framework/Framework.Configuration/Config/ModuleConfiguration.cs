// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Configuration.Model.Config
{
    public class ModuleConfiguration : ConfigurationSection
    {
        //
        // MODULE SERVICES
        //

        [ConfigurationProperty(Factory.Model.Config.Constants.SERVICES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(Factory.Model.Config.ServiceElementCollection))]
        public Factory.Model.Config.ServiceElementCollection Services
        {
            get { return (Factory.Model.Config.ServiceElementCollection)this[Factory.Model.Config.Constants.SERVICES]; }
        }
    }
}
