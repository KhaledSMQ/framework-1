// ============================================================================
// Project: Framework
// Name/Class: Hub
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime service set.
// ============================================================================

using Framework.Factory.API.Interface;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Factory.API.Default
{
    public class SrvHub : ACommon, IHub
    {
        //
        // CONSTRUCTORS
        //

        public SrvHub()
        {
            _Instances = new SortedDictionary<string, ICommon>();
        }

        //
        // GET SERVICE METHOD
        // Create Instance for Service.
        // @type (T) Is the full type for service.
        //

        public T Get<T>() where T : ICommon
        {
            //
            // Get the input type full name.
            //

            string fullTypeName = typeof(T).FullName;

            //
            // Based on the type full name, fetch the service configuration.
            //

            Service service = null;

            //
            // Return the service instance.
            //

            return Get<T>(service);
        }

        //
        // GET SERVICE METHOD
        // Create Instance for Service.
        // @key Is the name of the service as specified in application settings.
        //

        private T Get<T>(string key) where T : ICommon
        {
            //
            // Based on the key argument, fetch the object instane for the service. 
            // First check the key argument.
            //

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception(string.Format("{0}:{1} key argument is null or empty, please specify a valid value!", "", "ServiceLayer"));
            }

            //
            // Get the service configuration object.
            //            

            Service cfg = null;

            //
            // Instantiate it.
            //

            return Get<T>(cfg);
        }

        //
        // GET SERVICE METHOD
        //

        public T Get<T>(Service config) where T : ICommon
        {
            //
            // Check if service was already initialized.
            //

            T service = default(T);

            lock (_Instances)
            {
                if (_Instances.ContainsKey(config.Name))
                {
                    service = (T)_Instances[config.Name];
                }
                else
                {
                    //
                    // Create service instance.
                    //

                    service = Core.Reflection.Activator.CreateInstance<T>(config.TypeName);

                    //
                    // Initialize the service.
                    //

                    // service.Init(config, Ctx);

                    //
                    // Add service to the already defined instances.
                    //

                    _Instances.Add(config.Name, service);
                }
            }

            //
            // Return service instance to caller.
            //

            return service;
        }

        //
        // PRIVATE FIELDS
        //

        private IDictionary<string, ICommon> _Instances = null;
    }
}
