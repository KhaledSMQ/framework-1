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
        // Execute block yielding its result.
        //

        [ActionName("eval"), HttpGet]
        public IHttpActionResult Entity_Query([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IEval>().Eval(id, Request.Content.ReadAsStringAsync().Result); });
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        [ActionName("mem.import"), HttpPost]
        public IHttpActionResult Mem_Import(FW_BlkDomainDef item)
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Domain_Import(item); });
        }

        [ActionName("mem.dump"), HttpGet]
        public IHttpActionResult Mem_Dump()
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Dump(); });
        }

        [ActionName("mem.domains"), HttpGet]
        public IHttpActionResult Mem_Domains()
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Domain_GetList(); });
        }

        [ActionName("mem.modules"), HttpGet]
        public IHttpActionResult Mem_Modules()
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Module_GetList(); });
        }

        [ActionName("mem.blocks"), HttpGet]
        public IHttpActionResult Mem_Blocks()
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Block_GetList(); });
        }

        [ActionName("mem.clear"), HttpGet]
        public IHttpActionResult Mem_Clear()
        {
            return Run(() => { return Scope.Hub.GetUnique<IMemStore>().Clear(); });
        }
    }
}