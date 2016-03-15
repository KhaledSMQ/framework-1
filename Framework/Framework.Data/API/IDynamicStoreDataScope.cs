// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System;
using System.Linq;

namespace Framework.Data.API
{
    public interface IDynamicStoreDataScope : ICommon
    {
        object Create(string cluster, Type entity, object item);

        IQueryable Queryable(string cluster, Type entity);

        object Query(string cluster, Type entity, string name, params object[] args);

        object Update(string cluster, Type entity, object item);

        object Delete(string cluster, Type entity, object item);
    }
}
