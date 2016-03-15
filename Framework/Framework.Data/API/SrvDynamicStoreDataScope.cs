// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvDynamicStoreDataScope : ACommon, IDynamicStoreDataScope
    {  
        //
        // API
        //

        public object Create(string cluster, Type entity, object item)
        {
           return __GetDataSet(cluster, entity).Create(item);
        }

        public IQueryable Queryable(string cluster, Type entity)
        {
            return __GetDataSet(cluster, entity).Queryable();
        }

        public object Query(string cluster, Type entity, string name, params object[] args)
        {
            return __GetDataSet(cluster, entity).Query(name, args);
        }

        public object Update(string cluster, Type entity, object item)
        {
            return __GetDataSet(cluster, entity).Update(item);
        }

        public object Delete(string cluster, Type entity, object item)
        {
            return __GetDataSet(cluster, entity).Delete(item);
        }

        //
        // HELPERS
        //

        private IDynamicDataSet __GetDataSet(string cluster, Type entity)
        {
            return null;
        }

        private IDynamicDataObject __GetDataObject(string cluster, Type entity)
        {
            return null;
        }
    }
}
