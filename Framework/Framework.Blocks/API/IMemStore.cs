// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Mem;
using Framework.Blocks.Model.Schema;
using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.API
{
    public interface IMemStore : ICommon
    { 
        //
        // DOMAIN
        //    

        Id Domain_Import(FW_BlkDomainDef domain);

        MemDomain Domain_Get(Id id);

        IEnumerable<MemDomain> Domain_GetList();

        //
        // MODULES
        //

        Id Module_Import(Id domainID, FW_BlkModuleDef module);

        MemModule Module_Get(Id id);

        IEnumerable<MemModule> Module_GetList();     

        //
        // BLOCK
        //

        Id Block_Import(Id moduleID, FW_BlkBlockDef block);

        MemBlockTemplate Block_Get(Id id);

        IEnumerable<MemBlockTemplate> Block_GetList();         
    }
}
