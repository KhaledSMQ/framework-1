// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvDynamicClusterDataScope : ACommon, IDynamicClusterDataScope
    {  
        //
        // API
        //

        public object Create(Type entity, object item)
        {
           return __GetDataSet(entity).Create(item);
        }

        public IQueryable Queryable(Type entity)
        {
            return __GetDataSet(entity).Queryable();
        }

        public object Query(Type entity, string name, params object[] args)
        {
            return __GetDataSet(entity).Query(name, args);
        }

        public object Update(Type entity, object item)
        {
            return __GetDataSet(entity).Update(item);
        }

        public object Delete(Type entity, object item)
        {
            return __GetDataSet(entity).Delete(item);
        }

        //
        // HELPERS
        //

        private IDynamicDataSet __GetDataSet(Type entity)
        {
            return null;
        }

        private IDynamicDataObject __GetDataObject(Type entity)
        {
            return null;
        }
    }
}
