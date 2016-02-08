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
using System.Linq;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Factory.API.Default
{
    public class SrvHub : ACommon, IHub
    {
        public SrvHub()
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
                Load(_Entries.GetByName(name));
            }

            return Get<T>(_ByName[name]);
        }

        public T GetByTypeName<T>(string typeName) where T : ICommon
        {
            if (!_ByTypeName.ContainsKey(typeName))
            {
                Load(_Entries.GetByTypeName(typeName));
            }

            return Get<T>(_ByTypeName[typeName]);
        }

        public IEnumerable<T> GetByContract<T>() where T : ICommon
        {
            string contractTypeName = typeof(T).FullName;

            if (!_ByContract.ContainsKey(contractTypeName))
            {
                Load(_Entries.GetByContract(contractTypeName));
            }

            return _ByContract[contractTypeName].Map(new List<T>(), Get<T>);
        }

        public T Get<T>(ServiceEntry config) where T : ICommon
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

                    service = Core.Reflection.Activator.CreateGenericInstance<T>(config.TypeName);

                    //
                    // Initialize the service.
                    //

                    service.Init();

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
        // PRIVATE FIELDS
        //

        private IServiceEntry _Entries { get { return GetUnique<IServiceEntry>(); } }
        private IDictionary<string, ICommon> _Instances = null;
        private IDictionary<string, ServiceEntry> _ByName = null;
        private IDictionary<string, ServiceEntry> _ByTypeName = null;
        private IDictionary<string, IList<ServiceEntry>> _ByContract = null;
    }
}
