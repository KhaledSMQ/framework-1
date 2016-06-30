// ============================================================================
// Project: Framework
// Name/Class: ADynamicDataSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 14/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using System;
using System.Data.Entity;
using System.Linq;

namespace Framework.Data.EntityFramework.Objects
{
    public class BaseDynamicDataSet : ADynamicDataSet, IDynamicDataSet
    {
        //
        // PROPERTIES
        //

        public DbContext DataContext { get; set; }

        //
        // API
        //

        public override object Create(object item)
        {
            return DataContext.Set(Entity).Add(item);
        }

        public override IQueryable Queryable()
        {
            return DataContext.Set(Entity).AsQueryable();
        }

        public override object Query(string name, params object[] args)
        {
            return Queryable().ToListAsync().Result;
        }

        public override object Update(object item)
        {
            throw new NotSupportedException();
        }

        public override object Delete(object item)
        {
            return DataContext.Set(Entity).Remove(item);
        }

        public override void Save()
        {
            DataContext.SaveChanges();
        }
    }
}
