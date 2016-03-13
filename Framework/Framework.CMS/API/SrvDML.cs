// ============================================================================
// Project: Framework 
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 16/Mar/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.CMS.API
{
    public class SrvDML : ACommon, IDML
    {
        //
        // API
        //         

        public object Create<T>(T item, IDataSet<T> srv)
        {
            return srv.Create(item);
        }

        public T Get<T>(Func<IQueryable<T>, IQueryable<T>> query, IDataSet<T> srv)
        {
            return query(srv.Queryable()).SingleOrDefault();
        }

        public IEnumerable<T> GetList<T>(Func<IQueryable<T>, IQueryable<T>> query, IDataSet<T> srv)
        {
            return query(srv.Queryable()).ToList();
        }

        public object Update<T>(T item, IDataSet<T> srv)
        {
            return srv.Update(item);
        }

        public object Delete<T>(T item, IDataSet<T> srv)
        {
            return srv.Delete(item);
        }
    }
}
