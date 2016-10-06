// ============================================================================
// Project: Framework
// Name/Class: IGenericDataSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 14/Mar/2016
// Company: Coop4Creativity
// Description: Generic object data source.
// ============================================================================

using Framework.Core.Api;
using System.Linq;

namespace Framework.Data.Api
{
    public interface IGenericDataSet<TItem> : ICommon
    {
        //
        // CREATE
        //

        object Create(TItem item);

        //
        // QUERY
        //

        IQueryable<TItem> Queryable();

        object Query(string name, params object[] args);

        //
        // UPDATE
        //

        object Update(TItem item);

        //
        // DELETE
        //

        object Delete(TItem item);

        //
        // SAVE
        //

        void Save();
    }
}
