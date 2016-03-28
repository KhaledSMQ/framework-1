// ============================================================================
// Project: Framework
// Name/Class: IHub
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Service hub interface.
// ============================================================================

using Framework.Factory.Model;
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

        void Load(ServiceEntry entry);
    }
}
