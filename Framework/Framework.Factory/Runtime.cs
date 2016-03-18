// ============================================================================
// Project: Framework
// Name/Class: Runtime
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Factory runtime static object.
// ============================================================================

using Framework.Factory.API;
using Framework.Factory.Config;
using Framework.Factory.Model;
using Owin;
using System;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Factory
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
            //
            // Load base configuration.
            //

            LoadConfig();
        }

        //
        // Load the initial configuration for factory library.
        //

        public static void LoadConfig()
        {
            //
            // Load from the system configuration.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

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

                    __HubEntry = Transforms.Converter(config.Hub);
                    __HubEntry.Unique = true;

                    __Hub = Core.Reflection.Activator.CreateGenericInstance<IHub>(__HubEntry.TypeName);
                    __Hub.Init();
                    __Hub.Load(__HubEntry);

                    if (null != config.Services)
                    {
                        //
                        // Load core services into hub.
                        //
                        
                        __CoreServices = config.Services.Map<ServiceElement, ServiceEntry>(new List<ServiceEntry>(), Transforms.Converter);
                        __CoreServices.Apply(__Hub.Load);                       
                    }

                    //
                    // Setup the Scope service, load it
                    // and set it on the hub.
                    //

                    __Scope = __Hub.GetUnique<IScope>();
                    __Hub.Scope = __Scope;
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
        // HELPERS 
        //     

        private static IHub __Hub = null;
        private static ServiceEntry __HubEntry = null;
        private static IEnumerable<ServiceEntry> __CoreServices = null;
        private static IScope __Scope = null;
    }
}
