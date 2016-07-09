// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Model.Config;
using Framework.Factory.Model.Runtime;
using System.Collections.Generic;
using System.Reflection;
using Framework.Core.Extensions;
using Framework.Factory.API;
using Framework.Core.Reflection;
using System;

namespace Framework.Factory.Patterns
{
    public abstract class AModule<TConfig> : ACommon, IModule where TConfig : ModuleConfiguration
    {
        //
        // PROPERTIES
        //

        public IEnumerable<Service> Services { get { return GetListOfAvailableServices(); } }

        //
        // PROPERTIES (INTERNAL)
        //

        protected TConfig Config { get; set; }

        protected string ConfigSectionName { get; set; }

        protected Assembly Assembly { get; set; }

        //
        // CONSTRUCTOR
        //

        public AModule(string configSectionName, Assembly executingAssembly)
        {
            Config = default(TConfig);
            ConfigSectionName = configSectionName;
            Assembly = executingAssembly;
        }

        //
        // API
        //

        public virtual void LoadConfig()
        {
            //
            // Load from the system configuration spec
            //

            Config = (TConfig)System.Configuration.ConfigurationManager.GetSection(ConfigSectionName);
        }

        protected IEnumerable<Service> GetListOfAvailableServices()
        {
            List<Service> lst = new List<Service>();
            lst.AddRange(GetListOfUserServices());
            lst.AddRange(ExtractServicesFromAssembly());
            return lst;
        }

        protected IEnumerable<Service> GetListOfUserServices()
        {
            return Config.IsNotNull() ? Config.Services.Map<ServiceElement, Service>(Transforms.Config2Service) : new List<Service>();
        }

        //
        // Get from the module assembly the list of types that are services.
        // Services follow the ICommon interface pattern.
        //

        protected IEnumerable<Service> ExtractServicesFromAssembly()
        {
            return Assembly.GetTypesWithInterface(typeof(ICommon)).Map(typ =>
            {
                return new Service()
                {
                    Name = typ.FullName,
                    TypeName = Assembly.GetName() + ":" + typ.FullName,
                    Contract = "C"
                };
            });
        }
    }
}
