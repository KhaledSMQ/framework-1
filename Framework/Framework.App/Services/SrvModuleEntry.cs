// ============================================================================
// Project: Framework
// Name/Class: SrvModuleEntry
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.App.Api;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.App.Services
{
    public class SrvModuleEntry : ACommon, IModuleEntry
    {
        public override void Init()
        {
            base.Init();
            __Modules = new SortedDictionary<string, Core.Types.Specialized.Module>();
        }

        public void Load(Core.Types.Specialized.Module module)
        {
            if (null != module && module.Name.IsNotNullAndEmpty() && !__Modules.ContainsKey(module.Name))
            {
                //
                // Add the module item to the in-memory 
                // module data structure.
                //

                __Modules.Add(module.Name, module);

                //
                // Instantiate the module export interface
                // Load module configuration.
                // Import all the supported services and such.
                //

                IModule moduleProtocol = Core.Reflection.Activator.CreateGenericInstance<IModule>(module.TypeName);

                //
                // Load module configuration.
                //

                moduleProtocol.LoadConfig();

                //
                // Load module services into service hub.
                //

                moduleProtocol.Services.Apply(srv =>
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

        public void Load(IEnumerable<Core.Types.Specialized.Module> lst)
        {
            lst.Apply(Load);
        }

        public void Reload(string name)
        {
            if (name.IsNotNullAndEmpty())
            {
                Reload(GetByName(name));
            }
        }

        public void Reload(IEnumerable<string> lst)
        {
            lst.Apply(Reload);
        }

        public void Reload(Core.Types.Specialized.Module module)
        {
            if (null != module && module.Name.IsNotNullAndEmpty())
            {
                Unload(module);
                Load(module);
            }
        }

        public void Reload(IEnumerable<Core.Types.Specialized.Module> lst)
        {
            lst.Apply(Reload);
        }

        public Core.Types.Specialized.Module GetByName(string name)
        {
            return name.IsNotNullAndEmpty() ? GetList().SingleOrDefault(m => m.Name == name) : null;
        }

        public Core.Types.Specialized.Module GetByTypName(string typeName)
        {
            return typeName.IsNotNullAndEmpty() ? GetList().SingleOrDefault(m => m.TypeName == typeName) : null;
        }

        public IEnumerable<Core.Types.Specialized.Module> GetList()
        {
            return __Modules.Values;
        }

        public void Unload(string name)
        {
            if (name.IsNotNullAndEmpty() && __Modules.ContainsKey(name))
            {
                __Modules.Remove(name);
            }
        }

        public void Unload(IEnumerable<string> lst)
        {
            lst.Apply(Unload);
        }

        public void Unload(Core.Types.Specialized.Module module)
        {
            if (null != module && module.Name.IsNotNullAndEmpty())
            {
                Unload(module.Name);
            }
        }

        public void Unload(IEnumerable<Core.Types.Specialized.Module> lst)
        {
            lst.Apply(Unload);
        }

        public void Clear()
        {
            Unload(GetList());
        }

        //
        // In-memory area for storing modules.
        //

        private IDictionary<string, Core.Types.Specialized.Module> __Modules = null;
    }
}
