// ============================================================================
// Project: Framework
// Name/Class: SrvHost
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Host related properties and features.
// ============================================================================

using Framework.Configuration.Config;
using Framework.Configuration.Model;
using Framework.Core.Extensions;
using Framework.Factory.API;
using Framework.Factory.Patterns;
using Owin;
using System.Collections.Generic;

namespace Framework.Configuration.API
{
    public class SrvStartup : ACommon, IStartup
    {
        //
        // Service initialization.
        // Load configuration and boot service.
        //

        public override void Init()
        {
            base.Init();
            __LoadConfig();
        }

        //
        // Method to boot the application.
        // This will be called only one time.
        // When the application starts.
        //

        public void Startup(IAppBuilder app)
        {
            //
            // Run all services and all methods defined in sequence.
            //         

            __Sequence.Apply(call =>
            {
                Scope.Hub.GetUnique<IReflected>().Run(call.Service, call.Method);
            });
        }

        //
        // HELPER
        // Load configuration from config file.
        //

        private void __LoadConfig()
        {
            //
            // Load from configuration settings.
            //

            StartupConfiguration config = (StartupConfiguration)System.Configuration.ConfigurationManager.GetSection(_Const.SECTION_STARTUP);
            if (null != config)
            {
                if (null != config.Sequence)
                {
                    __Sequence = Config.Transforms.ToSequence(config.Sequence);
                }
            }
        }

        //
        // InMemory storage.
        //

        private IEnumerable<MethodCall> __Sequence = null;
    }
}
