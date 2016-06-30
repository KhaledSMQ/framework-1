// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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

        [ConfigurationProperty(_Const.META)]
        public MetaElement Meta
        {
            get { return (MetaElement)this[_Const.META]; }
        }
    }
}
