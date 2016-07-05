// ============================================================================
// Project: Framework
// Name/Class: Hub
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Runtime service set.
// ============================================================================

using Framework.Core.Collections.Specialized;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Factory.Model.Relational;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Framework.Factory.API
{
    public class SrvHub : ACommon, IHub
    {
        //
        // INIT
        //

        public override void Init()
        {
            //
            // Initialize base service , if any.
            //

            base.Init();

            //
            // In-memory service information.
            //

            _Instances = new SortedDictionary<string, ICommon>();
            _ByName = new SortedDictionary<string, FW_FactoryServiceEntry>();
            _ByTypeName = new SortedDictionary<string, IList<FW_FactoryServiceEntry>>();
            _ByContract = new SortedDictionary<string, IList<FW_FactoryServiceEntry>>();
        }

        //
        // API
        //

        public T GetUnique<T>() where T : ICommon
        {
            return GetUnique<T>(Scope);
        }

        public T GetUnique<T>(IScope whatScope) where T : ICommon
        {
            return GetByContract<T>(whatScope).FirstOrDefault();
        }

        public T Get<T>() where T : ICommon
        {
            return Get<T>(Scope);
        }

        public T Get<T>(IScope whatScope) where T : ICommon
        {
            FW_FactoryServiceEntry srvEntry = default(FW_FactoryServiceEntry);
            ICollection<FW_FactoryServiceEntry> srvEntryList = default(ICollection<FW_FactoryServiceEntry>);
            string contractTypeName = typeof(T).FullName;

            if (!_ByContract.ContainsKey(contractTypeName))
            {
                Load(_ServiceEntry.GetByContract(contractTypeName));
            }

            srvEntryList = _ByContract[contractTypeName];

            if (srvEntryList.NotEmpty())
            {
                srvEntry = srvEntryList.SingleOrDefault(entry => entry.Default);
                if (null == srvEntry)
                {
                    srvEntry = srvEntryList.First();
                }
            }

            return Get<T>(srvEntry, whatScope);
        }

        public T GetByName<T>(string name) where T : ICommon
        {
            return GetByName<T>(name, Scope);
        }

        public T GetByName<T>(string name, IScope whatScope) where T : ICommon
        {
            if (!_ByName.ContainsKey(name))
            {
                Load(_ServiceEntry.GetByName(name));
            }

            return Get<T>(_ByName[name], whatScope);
        }

        public IEnumerable<T> GetByTypeName<T>(string typeName) where T : ICommon
        {
            return GetByTypeName<T>(typeName, Scope);
        }

        public IEnumerable<T> GetByTypeName<T>(string typeName, IScope whatScope) where T : ICommon
        {
            if (!_ByTypeName.ContainsKey(typeName))
            {
                Load(_ServiceEntry.GetByTypeName(typeName));
            }

            return _ByContract[typeName].Map(new List<T>(), e => Get<T>(e, whatScope));
        }

        public IEnumerable<T> GetByType<T>(Type type) where T : ICommon
        {
            return GetByType<T>(type, Scope);
        }

        public IEnumerable<T> GetByType<T>(Type type, IScope whatScope) where T : ICommon
        {
            return GetByTypeName<T>(type.FullName, whatScope);
        }

        public IEnumerable<T> GetByContract<T>() where T : ICommon
        {
            return GetByContract<T>(Scope);
        }

        public IEnumerable<T> GetByContract<T>(IScope whatScope) where T : ICommon
        {
            string contractTypeName = typeof(T).FullName;

            if (!_ByContract.ContainsKey(contractTypeName))
            {
                Load(_ServiceEntry.GetByContract(contractTypeName));
            }

            return _ByContract[contractTypeName].Map(new List<T>(), e => Get<T>(e, whatScope));
        }

        public T Get<T>(FW_FactoryServiceEntry entry) where T : ICommon
        {
            return Get<T>(entry, Scope);
        }

        public T Get<T>(FW_FactoryServiceEntry entry, IScope whatScope) where T : ICommon
        {
            //
            // Check if service was already initialized.
            //

            T service = default(T);

            lock (_Instances)
            {
                if (_Instances.ContainsKey(entry.Name))
                {
                    service = (T)_Instances[entry.Name];
                }
                else
                {
                    //
                    // Create service instance.
                    //

                    service = New<T>(entry, whatScope);

                    //
                    // Add service to the already defined instances.
                    //

                    _Instances.Add(entry.Name, service);
                }
            }

            //
            // Return service instance to caller.
            //

            return service;
        }

        public T New<T>(FW_FactoryServiceEntry entry) where T : ICommon
        {
            return New<T>(entry, Scope);
        }

        public T New<T>(FW_FactoryServiceEntry entry, IScope whatScope) where T : ICommon
        {
            //
            // Check if service was already initialized.
            //

            T service = default(T);

            //
            // Create service instance.
            //

            service = Core.Reflection.Activator.CreateGenericInstance<T>(entry.TypeName);

            //
            // Initialize the service.
            //

            service.Scope = whatScope;
            service.Init();
            service.Cfg = __ProcessServiceSettings(entry.Settings);

            //
            // Load settings.
            // Parse and set its values.
            //

            __LoadServiceSettings(service);

            //
            // Return service instance to caller.
            //

            return service;
        }

        private IConfigMap __ProcessServiceSettings(ICollection<FW_FactorySetting> settings)
        {
            ConfigMap setMap = new ConfigMap();
            settings.Apply(setting => { setMap.Add(setting.Name, new Setting() { Name = setting.Name, Description = setting.Description, Value = setting.Value }); });
            return setMap;
        }

        private void __LoadServiceSettings(ICommon service)
        {
            IDictionary<string, KeyValuePair<Attributes.ServicePropertyAttribute, PropertyInfo>> setProperties = Core.Reflection.Attributes.GetPropsWithAttributes<Attributes.ServicePropertyAttribute>(service);

            setProperties.Values.Apply(pair =>
            {
                Attributes.ServicePropertyAttribute attr = pair.Key;
                PropertyInfo propInfo = pair.Value;


                string settingName = attr.Name;
                string settingValue = service.Cfg.GetRequired(settingName).Value;

                string propertyName = propInfo.Name;
                Type propertyType = propInfo.PropertyType;
                object propertyValue = Core.Reflection.Parsing.ParseTypeValue(propertyType, settingValue);

                Core.Reflection.Properties.SetProperty(service, propertyName, propertyValue);

            });
        }

        //
        // LOAD
        //

        public void Load(FW_FactoryServiceEntry entry)
        {
            if (!_ByName.ContainsKey(entry.Name))
            {
                _ByName.Add(entry.Name, entry);

                if (!_ByTypeName.ContainsKey(entry.TypeName))
                {
                    _ByTypeName.Add(entry.TypeName, new List<FW_FactoryServiceEntry>());
                }

                if (!_ByContract.ContainsKey(entry.Contract))
                {
                    _ByContract.Add(entry.Contract, new List<FW_FactoryServiceEntry>());
                }

                _ByTypeName[entry.TypeName].Add(entry);
                _ByContract[entry.Contract].Add(entry);
            }
        }

        public void Load(IEnumerable<FW_FactoryServiceEntry> lst)
        {
            lst.Apply(Load);
        }

        //
        // RETRIEVE-SECTION
        //

        public IEnumerable<FW_FactoryServiceEntry> GetListOfInstances()
        {
            return _Instances.Keys.Map(new List<FW_FactoryServiceEntry>(), name => { return _ByName[name]; });
        }

        public IEnumerable<FW_FactoryServiceEntry> GetListOfLoaded()
        {
            return _ByName.Values;
        }

        //
        // HELPERS
        //

        private IServiceEntry _GetServiceEntry()
        {
            if (null == _ServiceEntryValue)
            {
                //
                // Try to find the service entry definition.
                // Search in the loaded services.
                //

                _ByName.Values.Apply(entry =>
                {
                    if (entry.Contract.Trim() == typeof(IServiceEntry).FullName)
                    {
                        _ServiceEntryValue = Get<IServiceEntry>(entry);
                    }
                });

                //
                // If service entry is still null, then 
                // throw an error..
                // 

                if (null == _ServiceEntryValue)
                {
                    throw new Exception(string.Format("{0}: You must specifiy a valid '{1}' service", Lib.DEFAULT_ERROR_MSG_PREFIX, typeof(IServiceEntry).FullName));
                }
            }

            return _ServiceEntryValue;
        }

        //
        // PRIVATE FIELDS
        //

        private IServiceEntry _ServiceEntry { get { return _GetServiceEntry(); } }
        private IServiceEntry _ServiceEntryValue { get; set; }

        private IDictionary<string, ICommon> _Instances = null;
        private IDictionary<string, FW_FactoryServiceEntry> _ByName = null;
        private IDictionary<string, IList<FW_FactoryServiceEntry>> _ByTypeName = null;
        private IDictionary<string, IList<FW_FactoryServiceEntry>> _ByContract = null;
    }
}
