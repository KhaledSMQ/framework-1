// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

using Framework.Core.Config;
using System.Configuration;

namespace Framework.App.Config
{
    public class LibConfiguration : Core.Config.ModuleConfiguration
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
        // MODULES
        //

        [ConfigurationProperty(Constants.MODULES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ModuleImportElementCollection))]
        public ModuleImportElementCollection Modules
        {
            get { return (ModuleImportElementCollection)this[Constants.MODULES]; }
        }

        //
        // STARTUP
        //

        [ConfigurationProperty(Constants.STARTUP, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(MethodCallElementCollection))]
        public MethodCallElementCollection Sequence
        {
            get { return (MethodCallElementCollection)this[Constants.STARTUP]; }
        }
    }
}
