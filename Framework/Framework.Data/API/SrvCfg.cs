// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 31/May/2016
// Company: Coop4Creativity
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model.Config;
using Framework.Data.Model.Relational;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
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
            // the data store elements, domains and settings.
            //

            Config = (LibConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);
        }
    }
}
