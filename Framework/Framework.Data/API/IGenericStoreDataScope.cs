// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.Linq;

namespace Framework.Data.API
{
    public interface IGenericStoreDataScope : ICommon
    {
        object Create<T>(string cluster, T item);

        IQueryable<T> Queryable<T>(string cluster);

        object Query<T>(string cluster, string name, params object[] args);

        object Update<T>(string cluster, T item);

        object Delete<T>(string cluster, T item);
    }
}
