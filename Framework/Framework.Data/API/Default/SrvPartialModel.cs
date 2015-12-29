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

namespace Framework.Factory.API.Default.Config
{
    public class SrvPartialModel : AWrapperDataSet<PartialModel>, IPartialModel
    {
        public PartialModel GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public PartialModel GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
