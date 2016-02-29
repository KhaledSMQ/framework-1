// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Fev/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Patterns;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Framework.Data.EntityFramework.Objects
{
    public abstract class ADataSet<TItem> :
        Framework.Data.Patterns.ADataSet<TItem>, 
        IDataSet<TItem> 
        where TItem : class
    { 
        //
        // PROPERTIES
        //

        public DbContext DataContext { get; set; }

        //
        // CRUDs
        //

        public override object Create(TItem item)
        {
            return DataContext.Set<TItem>().Add(item);
        }

        public override TItem Get(TItem item)
        {
            throw new NotSupportedException();
        }

        public override TItem GetByID(object id)
        {
            return DataContext.Set<TItem>().Find(id);
        }

        public override IEnumerable<TItem> Query(object query)
        {
            if (null == query)
            {
                return Queryable().ToList();
            }
            else
            {
                //
                // TODO: Perform query...
                //

                throw new NotImplementedException();
            }            
        }

        public override IEnumerable<TItem> Query(string query)
        {
            object parsedQuery = null;
            return Query(parsedQuery);
        }

        public override IQueryable<TItem> Queryable()
        {
            return DataContext.Set<TItem>();
        }

        public override object Update(TItem item)
        {
            throw new NotSupportedException();
        }

        public override object DeleteByID(object id)
        {
            return Delete(GetByID(id));
        }

        public override object Delete(TItem item)
        {
            return DataContext.Set<TItem>().Remove(item);
        }

        public override void Save()
        {
            DataContext.SaveChanges();
        }
    }
}
