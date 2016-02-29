﻿// ============================================================================
// Project: Framework
// Name/Class: MAnager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime context implementation.
// ============================================================================

using Framework.Core.Collections.Specialized;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Factory.API.Interface;
using Framework.Factory.Config;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using Owin;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Factory.Runtime
{
    public static class Manager
    {
        //
        // PROPERTIES
        //

        public static IHub Hub { get { return __Hub; } }

        //
        // CONSTRUCTORS
        //

        static Manager() { }

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

            __HubEntry = Transforms.ToService(config.Hub);
            __CoreServices = Transforms.ToService(config.Services);

            //
            // Instantiate the hub service.
            // Load the hub service entry into the hub... :-)
            // 

            __HubEntry.Unique = true;
            __Hub = Core.Reflection.Activator.CreateGenericInstance<IHub>(__HubEntry.TypeName);
            __Hub.Init();
            __Hub.Load(__HubEntry);

            //
            // Load core services into hub.
            //

            __Hub.Load(__CoreServices);
        }

        //
        // HELPERS 
        //     

        private static IHub __Hub = null;
        private static ServiceEntry __HubEntry = null;
        private static IEnumerable<ServiceEntry> __CoreServices = null;
    }
}
