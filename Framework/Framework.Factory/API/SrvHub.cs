// ============================================================================
// Project: Framework
// Name/Class: Hub
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime service set.
// ============================================================================

using Framework.Core.Collections.Specialized;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Factory.Model;
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
            base.Init();
            __InitInMemoryStorage();
        }

        private void __InitInMemoryStorage()
        {
            _Instances = new SortedDictionary<string, ICommon>();
            _ByName = new SortedDictionary<string, ServiceEntry>();
            _ByTypeName = new SortedDictionary<string, IList<ServiceEntry>>();
            _ByContract = new SortedDictionary<string, IList<ServiceEntry>>();
        }

        //
        // API
        //

        public T GetUnique<T>() where T : ICommon
        {
            return GetByContract<T>().FirstOrDefault();
        }

        public T GetByName<T>(string name) where T : ICommon
        {
            if (!_ByName.ContainsKey(name))
            {
                Load(_ServiceEntry.GetByName(name));
            }

            return Get<T>(_ByName[name]);
        }

        public IEnumerable<T> GetByTypeName<T>(string typeName) where T : ICommon
        {
            if (!_ByTypeName.ContainsKey(typeName))
            {
                Load(_ServiceEntry.GetByTypeName(typeName));
            }

            return _ByContract[typeName].Map(new List<T>(), Get<T>);
        }

        public IEnumerable<T> GetByType<T>(Type type) where T : ICommon
        {
            return GetByTypeName<T>(type.FullName);
        }

        public IEnumerable<T> GetByContract<T>() where T : ICommon
        {
            string contractTypeName = typeof(T).FullName;

            if (!_ByContract.ContainsKey(contractTypeName))
            {
                Load(_ServiceEntry.GetByContract(contractTypeName));
            }

            return _ByContract[contractTypeName].Map(new List<T>(), Get<T>);
        }

        public T Get<T>(ServiceEntry entry) where T : ICommon
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

                    service = Core.Reflection.Activator.CreateGenericInstance<T>(entry.TypeName);

                    //
                    // Initialize the service.
                    //

                    service.Scope = Scope;
                    service.Init();
                    service.Cfg = _ProcessServiceSettings(entry.Settings);

                    //
                    // Load settings.
                    // Parse and set its values.
                    //

                    _LoadServiceSettings(service);

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

        private IConfigMap _ProcessServiceSettings(ICollection<Setting> settings)
        {
            ConfigMap setMap = new ConfigMap();
            settings.Apply(setting => { setMap.Add(setting.Name, setting); });
            return setMap;
        }

        private void _LoadServiceSettings(ICommon service)
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

        public void Load(ServiceEntry entry)
        {
            if (!_ByName.ContainsKey(entry.Name))
            {
                _ByName.Add(entry.Name, entry);

                if (!_ByTypeName.ContainsKey(entry.TypeName))
                {
                    _ByTypeName.Add(entry.TypeName, new List<ServiceEntry>());
                }

                if (!_ByContract.ContainsKey(entry.Contract))
                {
                    _ByContract.Add(entry.Contract, new List<ServiceEntry>());
                }

                _ByTypeName[entry.TypeName].Add(entry);
                _ByContract[entry.Contract].Add(entry);
            }
        }

        public void Load(IEnumerable<ServiceEntry> lst)
        {
            lst.Apply(Load);
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
        private IDictionary<string, ServiceEntry> _ByName = null;
        private IDictionary<string, IList<ServiceEntry>> _ByTypeName = null;
        private IDictionary<string, IList<ServiceEntry>> _ByContract = null;
    }
}
