﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Cryptography.Model.Config;
using Framework.Factory.Patterns;

namespace Framework.Cryptography.API
{
    public class SrvCfg : ACommon, ICfg
    {
        //
        // Internal state.
        //

        protected LibConfiguration Config;

        //
        // Load configuration.
        //

        public void Load()
        {
            //
            // Load from the system configuration spec
            //

            Config = (LibConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);
        }
    }
}
