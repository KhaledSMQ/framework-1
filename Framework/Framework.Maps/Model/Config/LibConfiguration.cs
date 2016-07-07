﻿// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

using System.Configuration;

namespace Framework.Maps.Model.Config
{
    public class LibConfiguration : ConfigurationSection
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
