// ============================================================================
// Project: Framework
// Name/Class: IModuleEntry
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.API;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.App.API
{
    public interface IModuleEntry : ICommon
    {
        void Load(Core.Types.Specialized.Module module);

        void Load(IEnumerable<Core.Types.Specialized.Module> lst);

        void Reload(string name);

        void Reload(IEnumerable<string> lst);

        void Reload(Core.Types.Specialized.Module module);

        void Reload(IEnumerable<Core.Types.Specialized.Module> lst);

        Core.Types.Specialized.Module GetByName(string name);

        Core.Types.Specialized.Module GetByTypName(string typeName);

        IEnumerable<Core.Types.Specialized.Module> GetList();

        void Unload(string name);

        void Unload(IEnumerable<string> lst);

        void Unload(Core.Types.Specialized.Module module);

        void Unload(IEnumerable<Core.Types.Specialized.Module> module);

        void Clear();
    }
}
