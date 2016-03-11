// ============================================================================
// Project: Framework
// Name/Class: IWrapperDataSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service contract for object sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.Patterns
{
    public interface IWrapperDataSet<TItem> : ICommon
    {
        //
        // CREATE
        //

        object Create(TItem item);

        IEnumerable<object> Create(IEnumerable<TItem> items);

        //
        // GET
        //

        TItem GetByID(object id);

        IEnumerable<TItem> GetByID(IEnumerable<object> ids);

        TItem Get(TItem item);

        IEnumerable<TItem> Get(IEnumerable<TItem> items);

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

        IEnumerable<object> Update(IEnumerable<TItem> items);

        //
        // DELETE 
        //

        object DeleteByID(object id);

        IEnumerable<object> DeleteByID(IEnumerable<object> ids);

        object Delete(TItem item);

        IEnumerable<object> Delete(IEnumerable<TItem> items);

        //
        // SAVE
        //

        void Save();
    }
}
