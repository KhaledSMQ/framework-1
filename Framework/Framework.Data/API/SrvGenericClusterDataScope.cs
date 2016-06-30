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
    public class SrvGenericClusterDataScope : ACommon, IGenericClusterDataScope
    {  
        //
        // API
        //

        public object Create<T>(T item)
        {
           return __GetDataSet<T>().Create(item);
        }

        public IQueryable<T> Queryable<T>()
        {
            return __GetDataSet<T>().Queryable();
        }

        public object Query<T>(string name, params object[] args)
        {
            return __GetDataSet<T>().Query(name, args);
        }

        public object Update<T>(T item)
        {
            return __GetDataSet<T>().Update(item);
        }

        public object Delete<T>(T item)
        {
            return __GetDataSet<T>().Delete(item);
        }

        //
        // HELPERS
        //

        private IGenericDataSet<T> __GetDataSet<T>()
        {
            return null;
        }

        private IGenericDataObject<T> __GetDataObject<T>()
        {
            return null;
        }
    }
}
