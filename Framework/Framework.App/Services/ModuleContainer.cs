// ============================================================================
// Project: Framework
// Name/Class: SrvModuleEntry
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.App.Api;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.App.Services
{
    public class ModuleContainer : ACommon, IModuleContainer
    {
        public override void Init()
        {
            base.Init();
            __ByType = new SortedDictionary<Type, IModule>();
            __ByName = new SortedDictionary<string, Type>();
        }

        //
        // LOAD
        //

        public void Load(Type type)
        {
            if (type.IsNotNull() && !__ByType.ContainsKey(type))
            {
                //
                // Instantiate the module export interface
                // Load module configuration.
                // Import all the supported services and such.
                //

                IModule module = Core.Reflection.Activator.CreateGenericInstance<IModule>(type.FullName);

                //
                // Add the module item to the in-memory 
                // module data structure.
                //

                __ByType.Add(type, module);
                __ByName.Add(module.Name, type);

                //
                // Load module configuration.
                //

                module.LoadConfig();

                //
                // Load module services into service hub.
                //

                module.Services.Apply(srv =>
                {
                    //
                    // Set the name for the module in service
                    // configuration.
                    //

                    srv.Module = module.Name;

                    //
                    // Add service to hub.
                    //

                    Scope.Hub.Load(srv);
                });
            }
        }

        public void Load(IEnumerable<Type> lst)
        {
            lst.Apply(Load);
        }

        public void Load()
        {
            //
            // Load all modules that are place in the
            // module repository, whatever that might be.
            //
        }

        //
        // RELOAD
        //

        public void Reload(string name)
        {
            Reload(__ByName[name]);
        }

        public void Reload(IEnumerable<string> lst)
        {
            lst.Apply(Reload);
        }

        public void Reload(Type type)
        {
            Unload(type);
            Load(type);
        }

        public void Reload(IEnumerable<Type> lst)
        {
            lst.Apply(Reload);
        }

        public void Reload()
        {  
            Unload();
            Load();
        }

        //
        // RETRIEVE
        //

        public IModule Get(string name)
        {
            return Get(__ByName[name]);
        }

        public IEnumerable<string> GetListOfNames()
        {
            return __ByName.Keys;
        }

        public IModule Get(Type type)
        {
            return __ByType[type];
        }

        public IEnumerable<Type> GetListOfTypes()
        {
            return __ByType.Keys;
        }

        //
        // UNLOAD
        //

        public void Unload(string name)
        {
            Unload(__ByName[name]);
        }

        public void Unload(IEnumerable<string> lst)
        {
            lst.Apply(Unload);
        }

        public void Unload(Type type)
        {
            if (type.IsNotNull() && __ByType.ContainsKey(type))
            {
                IModule module = Get(type);

                __ByType.Remove(type);
                __ByName.Remove(module.Name);

                //
                // Should we remove the list of services 
                // from the container?
                //
            }
        }

        public void Unload(IEnumerable<Type> lst)
        {
            lst.Apply(Unload);
        }

        public void Unload()
        {
            Unload(GetListOfTypes());
        }

        //
        // In-memory area for storing modules.
        //

        private IDictionary<Type, IModule> __ByType;
        private IDictionary<string, Type> __ByName;
    }
}
