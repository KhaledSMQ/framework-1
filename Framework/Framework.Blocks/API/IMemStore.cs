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

        void Domain_Import(FW_BlkDomain domain);

        MemDomain Domain_Get(Id id);

        IEnumerable<MemDomain> Domain_GetList();

        //
        // MODULES
        //

        Id Module_Import(Id domainID, FW_BlkModule module);

        MemModule Module_Get(Id id);

        IEnumerable<MemModule> Module_GetList();     

        //
        // BLOCK
        //

        Id Block_Import(Id moduleID, FW_BlkABlock block);

        MemBlock Block_Get(Id id);

        IEnumerable<MemBlock> Block_GetList();         
    }
}
