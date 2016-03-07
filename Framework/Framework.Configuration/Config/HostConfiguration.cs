// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Configuration.Config
{
    public class HostConfiguration : ConfigurationSection
    {
        //
        // META (application meta info, name, version, etc...)
        //

        [ConfigurationProperty(Constants.META)]
        public MetaElement Meta
        {
            get { return (MetaElement)this[Constants.META]; }
        }
    }
}
