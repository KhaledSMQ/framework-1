// ============================================================================
// Project: Framework
// Name/Class: Configuration for application meta information.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Configuration.Config
{
    public class MetaElement : BaseElement
    {
        //
        // VERSION
        //

        [ConfigurationProperty(Constants.VERSION, DefaultValue = "", IsRequired = false)]
        public string Version
        {
            get { return (string)this[Constants.VERSION]; }
            set { this[Constants.VERSION] = value; }
        }

        //
        // ICON
        //

        [ConfigurationProperty(Constants.ICON, DefaultValue = "", IsRequired = false)]
        public string Icon
        {
            get { return (string)this[Constants.ICON]; }
            set { this[Constants.ICON] = value; }
        }

        //
        // AUTHORS
        //

        [ConfigurationProperty(Constants.AUTHORS, DefaultValue = "", IsRequired = false)]
        public string Authors
        {
            get { return (string)this[Constants.AUTHORS]; }
            set { this[Constants.AUTHORS] = value; }
        }
    }
}
