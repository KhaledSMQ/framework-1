// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Api;
using Framework.Core.Config;
using Framework.Core.Extensions;
using Framework.Core.Helpers;
using Framework.Core.Reflection;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Framework.Core.Patterns
{
    public abstract class AModule<TConfig> : ACommon, IModule where TConfig : ModuleConfiguration
    {
        //
        // PROPERTIES
        //

        public string Name { get { return GetName(); } }

        public IEnumerable<Service> Services { get { return GetListOfAvailableServices(); } }

        //
        // PROPERTIES (Protected)
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

        public virtual string GetName()
        {
            return Base.GetConfigSectionName(Assembly).ToLower(CultureInfo.InvariantCulture);
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
            return Config.IsNotNull() ? Config.Services.Map<ServiceElement, Service>(ConfigHelper.Config2Service) : new List<Service>();
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
