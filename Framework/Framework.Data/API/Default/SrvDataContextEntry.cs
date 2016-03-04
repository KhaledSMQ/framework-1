// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.API.Interface;
using Framework.Data.Model;
using Framework.Data.Patterns;
using System.Linq;

namespace Framework.Data.API.Default
{
    public class SrvDataContextEntry : AWrapperDataSet<DataContext>, IDataContextEntry
    {
        public DataContext GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public DataContext GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.Service == type).FirstOrDefault();
        }
    }
}
