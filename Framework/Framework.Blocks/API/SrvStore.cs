// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

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

        public void LoadConfiguration()
        {
        }

        //
        // EVALUATE
        // Execute components.
        //

        public object Block_Evalute(string blockID, object args)
        {
            return null;
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        public object Mem_Dump()
        {
            return new {
                Domains = Mem_GetDomains(),
                Modules = Mem_GetModules(),
                Blocks = Mem_GetBlocks()
            };
        }

        public object Mem_GetDomains()
        {
            return srvMemStore.Domain_GetList();
        }

        public object Mem_GetModules()
        {
            return srvMemStore.Module_GetList();
        }

        public object Mem_GetBlocks()
        {
            return srvMemStore.Block_GetList();
        }
    }
}
