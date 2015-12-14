// ============================================================================
// Project: Framework
// Name/Class: IDataSetProvider
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Generic object data source.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.Patterns
{
    public interface IProviderDataSet<TItem> : IProvider
    {
        //
        // CREATE
        //

        object Create(TItem item);

        //
        // GET
        //

        TItem GetByID(object id);

        TItem Get(TItem item);

        //
        // QUERY
        //

        IQueryable<TItem> Queryable();

        IEnumerable<TItem> Query(string query);

        IEnumerable<TItem> Query(object query);

        //
        // UPDATE
        //

        object Update(TItem item);

        //
        // DELETE
        //

        object DeleteByID(object id);

        object Delete(TItem item);

        //
        // SAVE
        //

        void Save();
    }
}
