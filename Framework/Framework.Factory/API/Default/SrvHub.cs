﻿// ============================================================================
// Project: Framework
// Name/Class: Hub
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime service set.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Factory.API.Interface;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Factory.API.Default
{
    public class SrvHub : ACommon, IHub
    {
        //
        // PROPERTIES
        //

        public override void Init()
        {
            _Instances = new SortedDictionary<string, ICommon>();
            _ByName = new SortedDictionary<string, ServiceEntry>();
            _ByTypeName = new SortedDictionary<string, ServiceEntry>();
            _ByContract = new SortedDictionary<string, IList<ServiceEntry>>();
        }

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

        public T GetByTypeName<T>(string typeName) where T : ICommon
        {
            if (!_ByTypeName.ContainsKey(typeName))
            {
                Load(_ServiceEntry.GetByTypeName(typeName));
            }

            return Get<T>(_ByTypeName[typeName]);
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

        public void Load(ServiceEntry entry)
        {
            if (!_ByName.ContainsKey(entry.Name))
            {
                _ByName.Add(entry.Name, entry);
                _ByTypeName.Add(entry.TypeName, entry);

                if (!_ByContract.ContainsKey(entry.Contract))
                {
                    _ByContract.Add(entry.Contract, new List<ServiceEntry>());
                }

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
        private IDictionary<string, ServiceEntry> _ByTypeName = null;
        private IDictionary<string, IList<ServiceEntry>> _ByContract = null;
    }
}
