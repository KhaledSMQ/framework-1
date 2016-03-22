// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 21/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Blocks.API
{
    public class BlocksController : AController
    {
        //
        // EVALUATE
        // Execute components.
        //

        [ActionName("flow.evaluate"), HttpPost, HttpPut]
        public IHttpActionResult Entity_Create([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Flow_Evaluate(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("block.evaluate"), HttpGet]
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

        [ActionName("mem.flows"), HttpGet]
        public IHttpActionResult Mem_Flows()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetFlows(); });
        }

        [ActionName("mem.blocks"), HttpGet]
        public IHttpActionResult Mem_Blocks()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetBlocks(); });
        }
    }
}