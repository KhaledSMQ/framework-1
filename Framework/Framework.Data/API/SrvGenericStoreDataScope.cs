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
using System.Linq;

namespace Framework.Data.API
{
    public class SrvGenericStoreDataScope : ACommon, IGenericStoreDataScope
    {  
        //
        // API
        //

        public object Create<T>(string cluster, T item)
        {
           return __GetDataSet<T>(cluster).Create(item);
        }

        public IQueryable<T> Queryable<T>(string cluster)
        {
            return __GetDataSet<T>(cluster).Queryable();
        }

        public object Query<T>(string cluster, string name, params object[] args)
        {
            return __GetDataSet<T>(cluster).Query(name, args);
        }

        public object Update<T>(string cluster, T item)
        {
            return __GetDataSet<T>(cluster).Update(item);
        }

        public object Delete<T>(string cluster, T item)
        {
            return __GetDataSet<T>(cluster).Delete(item);
        }

        //
        // HELPERS
        //

        private IGenericDataSet<T> __GetDataSet<T>(string cluster)
        {
            return null;
        }

        private IGenericDataObject<T> __GetDataObject<T>(string cluster)
        {
            return null;
        }
    }
}
