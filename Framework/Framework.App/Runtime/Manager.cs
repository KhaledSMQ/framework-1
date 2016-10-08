// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Factory runtime static object.
// ============================================================================

using Framework.App.Api;
using Framework.App.Config;
using Framework.Core.Api;
using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Utils.Api;
using Owin;
using System;
using System.Collections.Generic;

namespace Framework.App.Runtime
{
    public static class Manager
    {
        //
        // PROPERTIES
        //

        public static IContainer Container { get; private set; }

        public static IModuleContainer ModuleContainer { get; private set; }

        public static IScope Scope { get; private set; }

        public static IHost Host { get; private set; }

        public static Lib Config { get; private set; }

        //
        // CONSTRUCTORS
        //

        static Manager() { }

        //
        // Initialize the data manager services.
        // 

        public static void Init(IAppBuilder app)
        {
            LoadConfig(app);
            LoadModules(app);
            Startup(app);
        }

        //
        // Load the initial configuration for factory library.
        //

        public static void LoadConfig(IAppBuilder app)
        {
            //
            // Load from the system configuration.
            //

            Config = (Lib)System.Configuration.ConfigurationManager.GetSection(Lib.DEFAULT_CONFIG_SECTION_NAME);

            //
            // Load configuration for the service hub.
            // If this is not found then no frameowrk exists.
            // This class will be the heart of the framework services.
            //            

            if (Config.IsNotNull())
            {
                if (Config.Hub.IsNotNull())
                {
                    //
                    // Instantiate the hub service.
                    // Load the hub service entry into the hub... :-)
                    // 

                    Service container = Core.Helpers.ConfigHelper.Config2Service(Config.Hub);
                    Container = Core.Reflection.Activator.CreateGenericInstance<IContainer>(container.TypeName);
                    Container.Init();
                    Container.Load(container);

                    //
                    // Load core services into hub.
                    //

                    if (null != Config.Services)
                    {
                        Container.Load(Config.Services.Map<Core.Config.ServiceElement, Service>(Core.Helpers.ConfigHelper.Config2Service));
                    }

                    //
                    // Setup the Scope service, load it
                    // and set it on the hub.
                    //

                    Scope = Container.Get<IScope>();
                    Container.Scope = Scope;

                    //
                    // Setup the host service.
                    //

                    Host = Container.Get<IHost>(Scope);

                    //
                    // Setup the module manager service.
                    //

                    ModuleContainer = Container.Get<IModuleContainer>(Scope);
                }
                else
                {
                    //
                    // ERROR: Hub service specification was not found in factory configuration!
                    //

                    throw new Exception("Container service specification was not found in factory configuration!");
                }
            }
            else
            {
                //
                // ERROR: Configuration section for factory not found!
                //

                throw new Exception("Configuration section for factory not found!");
            }
        }

        //
        // Method to boot the application.
        // This will be called only one time.
        // When the application starts.
        //

        public static void Startup(IAppBuilder app)
        {
            //
            // Run all services and all methods defined in sequence.
            //         

            if (null != Config.Sequence)
            {
                IEnumerable<MethodCall> bootSequence = Config.Sequence.Map<MethodCallElement, MethodCall>(App.Api.Transforms.Config2MethodCall);

                bootSequence.Apply((Action<MethodCall>)(call =>
                {
                    Scope.Hub.Get<IReflected>().Run(call.Service, call.Method);
                }));
            }
        }

        //
        // Method to load all the modules into the module manager.
        // The module manager will load the inport artifacts into
        // the runtime syste,
        //

        public static void LoadModules(IAppBuilder app)
        {
            if (Config.Modules.IsNotNull())
            {
                ModuleContainer.Load(Config.Modules.Map<ModuleImportElement, Type>(modImport =>
                {
                    return Core.Reflection.Parsing.ParseTypeName(modImport.Type);
                }));
            }
        }
    }
}
