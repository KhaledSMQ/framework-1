// ============================================================================
// Project: Framework
// Name/Class: IService
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public interface IServiceEntry : ICommon
    {
        object Create(ServiceEntry srv);

        ServiceEntry GetByName(string name);

        IEnumerable<ServiceEntry> GetByContract(string contract);

        ServiceEntry GetByTypeName(string type);
    }
}
