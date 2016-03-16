// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface IMemStore : ICommon
    { 
        //
        // DOMAINS
        //    

        void LoadDomain(DataDomain domain);

        DataDomain GetDomain(params string[] parcels);

        IEnumerable<string> GetListOfDomains();

        void InitDomain(string domainID);

        //
        // ENTITIES
        //

        DataEntity GetEntity(params string[] parcels);

        Type GetEntityType(params string[] parcels);

        IProviderDataContext GetEntityDataProviderContext(params string[] parcels);
    }
}
