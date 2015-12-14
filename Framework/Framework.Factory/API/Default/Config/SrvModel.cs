// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.API.Interface.Config;
using Framework.Factory.Patterns;
using System.Linq;
using CONFIG = Framework.Factory.Model.Config;

namespace Framework.Factory.API.Default.Config
{
    public class SrvModel : AWrapperDataSet<CONFIG.Model>, IModel
    {
        public CONFIG.Model GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public CONFIG.Model GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
