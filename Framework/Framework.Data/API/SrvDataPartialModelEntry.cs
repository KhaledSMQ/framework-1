// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvDataPartialModelEntry : AWrapperDataSet<DataPartialModel>, IDataPartialModelEntry
    {
        public DataPartialModel GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public DataPartialModel GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
