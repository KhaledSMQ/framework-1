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
    public interface IDynamicClusterDataScope : ICommon
    {
        object Create(Type entity, object item);

        IQueryable Queryable(Type entity);

        object Query(Type entity, string name, params object[] args);

        object Update(Type entity, object item);

        object Delete(Type entity, object item);
    }
}
