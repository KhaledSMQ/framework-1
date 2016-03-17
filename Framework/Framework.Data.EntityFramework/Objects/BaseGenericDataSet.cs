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
using System.Data.Entity;
using System.Linq;

namespace Framework.Data.EntityFramework.Objects
{
    public class BaseGenericDataSet<TItem> :
        AGenericDataSet<TItem>,
        IGenericDataSet<TItem>
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

        public override IQueryable<TItem> Queryable()
        {
            return DataContext.Set<TItem>();
        }

        public override object Query(string name, params object[] args)
        {
            return Queryable().ToList();
        }

        public override object Update(TItem item)
        {
            throw new NotSupportedException();
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
