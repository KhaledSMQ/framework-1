// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Model.Config;
using System.Configuration;

namespace Framework.Factory.Config
{
    public class StartupConfiguration : ConfigurationSection
    {        
        //
        // BOOT-SEQUENCE
        // Ordered list of services and method to run at startup.
        //

        [ConfigurationProperty(Constants.SEQUENCE, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(MethodCallElementCollection))]
        public MethodCallElementCollection Sequence
        {
            get { return (MethodCallElementCollection)this[Constants.SEQUENCE]; }
        }
    }
}
