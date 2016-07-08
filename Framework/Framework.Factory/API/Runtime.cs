// ============================================================================
// Project: Framework
// Name/Class: Runtime
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Factory runtime static object.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Factory.Model.Config;
using Framework.Factory.Model.Relational;
using Framework.Factory.Model.Runtime;
using Owin;
using System;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public static class Runtime
    {
        //
        // PROPERTIES
        //

        public static IHub Hub { get { return __Hub; } }

        public static IScope Scope { get { return __Scope; } }

        //
        // CONSTRUCTORS
        //

        static Runtime() { }

        //
        // Initialize the data manager services.
        // 

        public static void Init(IAppBuilder app)
        {
            LoadConfig();
            Startup(app);
        }

        //
        // Load the initial configuration for factory library.
        //

        public static void LoadConfig()
        {
            //
            // Load from the system configuration.
            //

            LibConfiguration config = (LibConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Load configuration for the service hub.
            // If this is not found then no frameowrk exists.
            // This class will be the heart of the framework services.
            //            

            if (null != config)
            {
                if (null != config.Hub)
                {
                    //
                    // Instantiate the hub service.
                    // Load the hub service entry into the hub... :-)
                    // 

                    FW_FactoryServiceEntry __HubEntry = Transforms.Converter(config.Hub);
                    __HubEntry.Unique = true;

                    __Hub = Core.Reflection.Activator.CreateGenericInstance<IHub>(__HubEntry.TypeName);
                    __Hub.Init();
                    __Hub.Load(__HubEntry);

                    if (null != config.Services)
                    {
                        //
                        // Load core services into hub.
                        //

                        __Hub.Load(config.Services.Map<ServiceElement, FW_FactoryServiceEntry>(new List<FW_FactoryServiceEntry>(), Transforms.Converter));
                    }

                    //
                    // Setup the Scope service, load it
                    // and set it on the hub.
                    //

                    __Scope = __Hub.GetUnique<IScope>();
                    __Hub.Scope = __Scope;

                    //
                    // Load boot sequence.
                    //

                    __Sequence = Transforms.ToSequence(config.Sequence);
                }
                else
                {
                    //
                    // ERROR: Hub service specification was not found in factory configuration!
                    //

                    throw new Exception("Hub service specification was not found in factory configuration!");
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

            __Sequence.Apply(call =>
            {
                __Scope.Hub.GetUnique<IReflected>().Run(call.Service, call.Method);
            });
        }

        //
        // HELPERS 
        //     

        private static IHub __Hub = null;
        private static IScope __Scope = null;
        private static IEnumerable<MethodCall> __Sequence = null;

    }
}
