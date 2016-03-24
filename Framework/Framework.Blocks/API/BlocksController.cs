// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 21/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Blocks.Model.Schema;
using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Blocks.API
{
    public class BlocksController : AController
    {
        //
        // EVALUATE
        // Execute blocks.
        //

        [ActionName("eval"), HttpGet]
        public IHttpActionResult Entity_Query([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Block_Evalute(id, Request.Content.ReadAsStringAsync().Result); });
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        [ActionName("mem.dump"), HttpGet]
        public IHttpActionResult Mem_Dump()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_Dump(); });
        }

        [ActionName("mem.domains"), HttpGet]
        public IHttpActionResult Mem_Domains()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetDomains(); });
        }

        [ActionName("mem.modules"), HttpGet]
        public IHttpActionResult Mem_Modules()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetModules(); });
        }

        [ActionName("mem.blocks"), HttpGet]
        public IHttpActionResult Mem_Blocks()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetBlocks(); });
        }

        [ActionName("mem.clear"), HttpGet]
        public IHttpActionResult Mem_Clear()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_Clear(); });
        }

        //
        // DEBUG
        // Debug hooks.
        //

        [ActionName("debug.import.domain"), HttpPost]
        public IHttpActionResult Debug_Import_Domain(FW_BlkDomainDef item)
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Domain_Import(item); });
        }

        [ActionName("debug.clear"), HttpPost]
        public IHttpActionResult Debug_Clear(FW_BlkDomainDef item)
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Domain_Import(item); });
        }
    }
}