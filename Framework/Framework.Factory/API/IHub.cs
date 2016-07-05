// ============================================================================
// Project: Framework
// Name/Class: IHub
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Service hub interface.
// ============================================================================

using Framework.Factory.Model.Schema;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public interface IHub : ICommon
    {
        T GetUnique<T>() where T : ICommon;

        T GetUnique<T>(IScope whatScope) where T : ICommon;

        T Get<T>() where T : ICommon;

        T Get<T>(IScope whatScope) where T : ICommon;

        T GetByName<T>(string name) where T : ICommon;

        T GetByName<T>(string name, IScope whatScope) where T : ICommon;

        IEnumerable<T> GetByTypeName<T>(string typeName) where T : ICommon;

        IEnumerable<T> GetByTypeName<T>(string typeName, IScope whatScope) where T : ICommon;

        IEnumerable<T> GetByType<T>(Type type) where T : ICommon;

        IEnumerable<T> GetByType<T>(Type type, IScope whatScope) where T : ICommon;

        IEnumerable<T> GetByContract<T>() where T : ICommon;

        IEnumerable<T> GetByContract<T>(IScope whatScope) where T : ICommon;

        T Get<T>(ServiceEntry cfg) where T : ICommon;

        T Get<T>(ServiceEntry cfg, IScope whatScope) where T : ICommon;

        T New<T>(ServiceEntry cfg) where T : ICommon;

        T New<T>(ServiceEntry cfg, IScope whatScope) where T : ICommon;

        //
        // LOAD-SECTION
        // Load service entries into memory.
        //

        void Load(ServiceEntry entry);

        void Load(IEnumerable<ServiceEntry> lst);

        //
        // RETRIEVE-SECTION
        //

        IEnumerable<ServiceEntry> GetListOfInstances();

        IEnumerable<ServiceEntry> GetListOfLoaded();
    }
}
