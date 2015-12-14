// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.API.Interface.Config;
using Framework.Factory.Model;
using Framework.Factory.Model.Config;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Factory.API.Default.Config
{
    public class SrvService : AWrapperDataSet<Service>, IService
    {
        public Service GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public IEnumerable<Service> GetByContract(string contract)
        {
            return DataLayer.Queryable().Where(i => i.Contract == contract).ToList();
        }

        public Service GetByType(string type)
        {
            return DataLayer.Queryable().Where(i => i.Type == type).FirstOrDefault();
        }
    }
}
