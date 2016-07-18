// ============================================================================
// Project: Framework
// Name/Class: IModuleEntry
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Model.Runtime;
using System.Collections.Generic;

namespace Framework.Core.API
{
    public interface IModuleEntry : ICommon
    {
        void Load(Module module);

        void Load(IEnumerable<Module> lst);

        void Reload(string name);

        void Reload(IEnumerable<string> lst);

        void Reload(Module module);

        void Reload(IEnumerable<Module> lst);

        Module GetByName(string name);

        Module GetByTypName(string typeName);

        IEnumerable<Module> GetList();

        void Unload(string name);

        void Unload(IEnumerable<string> lst);

        void Unload(Module module);

        void Unload(IEnumerable<Module> module);

        void Clear();
    }
}
