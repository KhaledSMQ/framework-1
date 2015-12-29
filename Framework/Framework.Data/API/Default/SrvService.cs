// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.API.Interface;
using Framework.Factory.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Framework.Factory.API.Default.Config
{
    public class SrvService : AWrapperDataSet<Service>, IService
    {
        public override object Create(Service srv)
        {
            return DataLayer.Create(srv);
        }

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
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
