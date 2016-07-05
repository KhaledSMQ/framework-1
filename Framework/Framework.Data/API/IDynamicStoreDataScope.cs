// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
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
