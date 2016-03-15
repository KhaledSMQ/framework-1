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
    public interface IDynamicClusterDataScope : ICommon
    {
        object Create(Type entity, object item);

        IQueryable Queryable(Type entity);

        object Query(Type entity, string name, params object[] args);

        object Update(Type entity, object item);

        object Delete(Type entity, object item);
    }
}
