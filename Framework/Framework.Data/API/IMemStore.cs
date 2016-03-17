// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model.Diagnostics;
using Framework.Data.Model.Schema;
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

        void Domain_Load(DataDomain domain);

        DataDomain Domain_Get(params string[] parcels);

        IEnumerable<string> Domain_GetListOfID();

        void Domain_Init(string domainID);

        //
        // ENTITIES
        //

        DataEntity Entity_Get(params string[] parcels);

        Type Entity_GetType(params string[] parcels);

        IProviderDataContext Entity_GetProviderDataContext(params string[] parcels);

        //
        // DIAGNOSTICS
        //

        IEnumerable<MemDomain> Mem_GetListOfDomains();

        IEnumerable<MemContext> Mem_GetListOfContexts();

        IEnumerable<MemEntity> Mem_GetListOfEntities();
    }
}
