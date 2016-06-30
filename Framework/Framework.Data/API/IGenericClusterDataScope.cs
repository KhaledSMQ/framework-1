// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.Linq;

namespace Framework.Data.API
{
    public interface IGenericClusterDataScope : ICommon
    {
        object Create<T>(T item);

        IQueryable<T> Queryable<T>();

        object Query<T>(string name, params object[] args);

        object Update<T>(T item);

        object Delete<T>(T item);
    }
}
