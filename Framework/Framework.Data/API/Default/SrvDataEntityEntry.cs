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
    public class SrvDataEntityEntry : AWrapperDataSet<DataEntity>, IDataEntityEntry
    {
        public DataEntity GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public DataEntity GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.Service == type).FirstOrDefault();
        }
    }
}
