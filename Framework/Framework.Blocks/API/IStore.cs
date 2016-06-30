// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 21/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;

namespace Framework.Blocks.API
{
    public interface IStore : ICommon
    {
        //
        // Load configuration settings for the store.
        // This will load all settings but also the 
        // data domains that are defined on the configuration
        // store.
        //

        void LoadConfiguration();

        //
        // BLOCKS        
        // Methods for managing blocks.
        //

        object Block_Create(string moduleID, object block);

        object Block_Create(Id moduleID, object block);

        object Block_Get(string blockID);

        object Block_Get(Id blockID);

        object Block_Exists(string blockID);

        object Block_Exists(Id blockID);

        object Block_GetList();

        object Block_GetListByDomain(string domainID);

        object Block_GetListByDomain(Id domainID);

        object Block_GetListByModule(string moduleID);

        object Block_GetListByModule(Id moduleID);
    }
}
