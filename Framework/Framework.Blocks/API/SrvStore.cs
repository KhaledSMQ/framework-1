// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using Framework.Core.Extensions;
using Framework.Blocks.Model.Mem;
using System.Collections.Generic;

namespace Framework.Blocks.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // Service dependencies.
        //

        protected IMemStore srvMemStore { get; set; }

        //
        // Service initialization. 
        // Boot the dependant services.
        //

        public override void Init()
        {
            //
            // Initialize base service infrastructure.
            //

            base.Init();

            //
            // Initialize dependent services.
            // NOTE: We do this here because all these services
            // do not have dependencies that are circular to this service.
            //

            srvMemStore = Scope.Hub.GetUnique<IMemStore>();
        }

        //
        // Load configuration values from the configuration store.
        // Load all settings, but also the data domains defined.
        //

        public void LoadConfiguration() { }

        //
        // BLOCKS        
        // Methods for managing blocks.
        //

        public object Block_Create(string moduleID, object block)
        {
            return Block_Create(Id.FromString(moduleID), block);
        }

        public object Block_Create(Id moduleID, object block)
        {
            return null;
        }

        public object Block_Get(string blockID)
        {
            return Block_Get(Id.FromString(blockID));
        }

        public object Block_Get(Id blockID)
        {
            //
            // Default value for block.
            // NOTE: We decided that we should use the 
            // object data type because we like this to
            // be as decoupled as possible.
            //

            object block = default(object);

            //
            // Check if block was already loaded
            // and is up to date. If none of the
            // previous is true, then we need to
            // (re) load the block. This may mean
            // load the block module and/or module.
            // 

            if (!srvMemStore.Block_Exists(blockID))
            {
                //
                // TODO: If block does not exist im memory 
                // store, then we should load it.
                //                
            }

            block = srvMemStore.Block_Get(blockID);

            //
            // Return the block definition to caller.
            // Its up to them to check if the value 
            // is valid.
            //

            return block;
        }

        public object Block_Exists(string blockID)
        {
            return Block_Exists(Id.FromString(blockID));
        }

        public object Block_Exists(Id blockID)
        {
            return srvMemStore.Block_Exists(blockID);
        }

        public object Block_GetList()
        {
            return srvMemStore.Block_GetList();
        }

        public object Block_GetListByDomain(string domainID)
        {
            return Block_GetListByDomain(Id.FromString(domainID));
        }

        public object Block_GetListByDomain(Id domainID)
        {
            return srvMemStore.Domain_Get(domainID).Modules
                .Map(new List<MemModule>(), srvMemStore.Module_Get)
                .Catamorphism<IList<MemBlockDef>, MemModule>(new List<MemBlockDef>(), (module, tail) =>
                {
                    tail.AddRange(module.Blocks.Map(new List<MemBlockDef>(), srvMemStore.Block_Get));
                    return tail;
                });
              
        }

        public object Block_GetListByModule(string moduleID)
        {
            return Block_GetListByModule(Id.FromString(moduleID));
        }

        public object Block_GetListByModule(Id moduleID)
        {
            return srvMemStore.Module_Get(moduleID).Blocks.Map(new List<MemBlockDef>(), srvMemStore.Block_Get);
        }
    }
}
