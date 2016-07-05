// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Blocks.Model.Mem;
using Framework.Blocks.Model.Schema;
using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.API
{
    public interface IMem : ICommon
    {
        //
        // STORE
        //

        object Dump();

        object Clear();

        //
        // DOMAIN
        //    

        Id Cluster_Import(FW_BlkClusterDef domain);
        
        MemCluster Cluster_Get(Id id);

        bool Cluster_Exists(Id id);

        IEnumerable<MemCluster> Cluster_GetList();

        void Cluster_Unload(MemCluster domain);

        void Cluster_Unload(string domainID);

        void Cluster_Unload(Id domainID);

        int Cluster_Clear();

        //
        // MODULES
        //

        Id Module_Import(Id domainID, FW_BlkModuleDef module);

        MemModule Module_Get(Id id);

        bool Module_Exists(Id id);

        IEnumerable<MemModule> Module_GetList();     

        //
        // BLOCK
        //

        Id Block_Import(Id moduleID, FW_BlkBlockDef block);

        MemBlockDef Block_Get(Id id);

        bool Block_Exists(Id id);

        IEnumerable<MemBlockDef> Block_GetList();         
    }
}
