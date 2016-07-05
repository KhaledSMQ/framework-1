// ============================================================================
// Project: Framework
// Name/Class: Configuration for application meta information.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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

        [ConfigurationProperty(_Const.VERSION, DefaultValue = "", IsRequired = false)]
        public string Version
        {
            get { return (string)this[_Const.VERSION]; }
            set { this[_Const.VERSION] = value; }
        }

        //
        // ICON
        //

        [ConfigurationProperty(_Const.ICON, DefaultValue = "", IsRequired = false)]
        public string Icon
        {
            get { return (string)this[_Const.ICON]; }
            set { this[_Const.ICON] = value; }
        }

        //
        // AUTHORS
        //

        [ConfigurationProperty(_Const.AUTHORS, DefaultValue = "", IsRequired = false)]
        public string Authors
        {
            get { return (string)this[_Const.AUTHORS]; }
            set { this[_Const.AUTHORS] = value; }
        }
    }
}
