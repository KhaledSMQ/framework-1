// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.API;
using Framework.Factory.Model.Relational;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvServiceEntry : ACommon, IServiceEntry
    {
        private IGenericDataSet<FW_FactoryServiceEntry> DataLayer = null;

        public object Create(FW_FactoryServiceEntry srv)
        {
            return DataLayer.Create(srv);
        }

        public FW_FactoryServiceEntry GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }

        public IEnumerable<FW_FactoryServiceEntry> GetByContract(string contract)
        {
            return DataLayer.Queryable().Where(i => i.Contract == contract).ToList();
        }

        public FW_FactoryServiceEntry GetByTypeName(string type)
        {
            return DataLayer.Queryable().Where(i => i.TypeName == type).FirstOrDefault();
        }
    }
}
