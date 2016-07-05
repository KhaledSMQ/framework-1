// ============================================================================
// Project: Framework
// Name/Class: IService
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Model.Relational;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public interface IServiceEntry : ICommon
    {
        object Create(FW_FactoryServiceEntry srv);

        FW_FactoryServiceEntry GetByName(string name);

        IEnumerable<FW_FactoryServiceEntry> GetByContract(string contract);

        FW_FactoryServiceEntry GetByTypeName(string type);
    }
}
