// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Model.Config;
using Framework.Factory.Patterns;

namespace Framework.Factory.API
{
    public class SrvModule<TConfig> : ACommon, IModule where TConfig : ModuleConfiguration
    {
        //
        // Internal state.
        //

        protected TConfig Config;
        protected string ConfigSectionName;

        public SrvModule(string configSectionName)
        {
            ConfigSectionName = configSectionName;
        }

        //
        // Load configuration.
        //

        public void LoadConfig()
        {
            //
            // Load from the system configuration spec
            //

            Config = (TConfig)System.Configuration.ConfigurationManager.GetSection(ConfigSectionName);
        }
    }
}
