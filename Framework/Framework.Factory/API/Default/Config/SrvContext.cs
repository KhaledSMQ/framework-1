// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.API.Interface.Config;
using Framework.Factory.Model.Config;
using Framework.Factory.Patterns;
using System.Linq;

namespace Framework.Factory.API.Default.Config
{
    public class SrvContext : AWrapperDataSet<Context>, IContext
    {
        public Context GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public Context GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
