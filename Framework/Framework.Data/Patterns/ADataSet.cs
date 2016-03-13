// ============================================================================
// Project: Framework
// Name/Class: AWrapperDataObject
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service for single object sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.Patterns
{
    public abstract class ADataSet<TItem> : ACommon, IDataSet<TItem>
    {
        //
        // PROPERTIES
        //

        public IConfigMap Cfg { get; set; }   

        //
        // CRUD
        //

        public abstract object Create(TItem item);

        public abstract TItem GetByID(object id);

        public abstract TItem Get(TItem item);

        public virtual TItem Get(Func<IQueryable<TItem>, IQueryable<TItem>> query)
        {
            return query(Queryable()).SingleOrDefault();
        }

        public abstract IEnumerable<TItem> Query(object query);

        public abstract IEnumerable<TItem> Query(string query);

        public abstract IQueryable<TItem> Queryable();

        public abstract object Update(TItem item);

        public abstract object DeleteByID(object id);

        public abstract object Delete(TItem item);

        public abstract void Save();
    }
}
