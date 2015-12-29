// ============================================================================
// Project: Framework
// Name/Class: IService
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Service configuration interface.
// ============================================================================

using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Factory.API.Interface
{
    public interface IService : ICommon
    {
        object Create(Service srv);

        Service GetByName(string name);

        IEnumerable<Service> GetByContract(string contract);

        Service GetByType(string type);
    }
}
