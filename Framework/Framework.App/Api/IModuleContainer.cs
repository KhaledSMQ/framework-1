// ============================================================================
// Project: Framework
// Name/Class: IModuleEntry
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Api;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.App.Api
{
    public interface IModuleContainer : ICommon
    {
        //
        // LOAD
        //

        void Load(Type type);

        void Load(IEnumerable<Type> lst);

        void Load();

        //
        // RELOAD
        //

        void Reload(string name);

        void Reload(IEnumerable<string> lst);

        void Reload(Type type);

        void Reload(IEnumerable<Type> lst);

        void Reload();

        //
        // RETRIEVE
        //

        IModule Get(string name);

        IEnumerable<string> GetListOfNames();

        IModule Get(Type type);

        IEnumerable<Type> GetListOfTypes();

        //
        // UNLOAD
        //

        void Unload(string name);

        void Unload(IEnumerable<string> lst);

        void Unload(Type type);

        void Unload(IEnumerable<Type> lst);

        void Unload();
    }
}
