// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Blocks.Model.Schema;
using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Blocks.API
{
    public abstract class ABlocksController : AController
    {
        //
        // EVALUATE
        // Execute block yielding its result.
        //

        [ActionName("eval"), HttpPost]
        public IHttpActionResult Eval([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IEval>().Eval(id, GetRequestContentAsString(string.Empty)); });
        }

        [ActionName("eval.stage.evalBlock"), HttpPost]
        public IHttpActionResult Eval_StageEvalBlock([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IEval>().Eval_StageEvalBlock(id, GetRequestContentAsString(string.Empty)); });
        }

        //
        // BLOCK
        // Management.
        //

        [ActionName("block.create"), HttpPost]
        public IHttpActionResult Block_Create(string id, FW_BlkBlockDef item)
        {
            //
            // Paramter 'id' is the module complete identifier where to add
            // this block. The module must already exists, otherwise this operation
            // will fail.
            //

            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Block_Create(id, item); });
        }

        [ActionName("block.get"), HttpGet]
        public IHttpActionResult Block_Get(string id)
        {
            //
            // Paramter 'id' is the block complete identifier, something like:
            //
            //   <CLUSTER>.<MODULE0>. ... .<MODULEn>.<NAME>
            //
            //

            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Block_Get(id); });
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        [ActionName("mem.import"), HttpPost]
        public IHttpActionResult Mem_Import(FW_BlkClusterDef item)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Cluster_Import(item); });
        }

        [ActionName("mem.dump"), HttpGet]
        public IHttpActionResult Mem_Dump()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Dump(); });
        }

        [ActionName("mem.clusters"), HttpGet]
        public IHttpActionResult Mem_Domains()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Cluster_GetList(); });
        }

        [ActionName("mem.modules"), HttpGet]
        public IHttpActionResult Mem_Modules()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Module_GetList(); });
        }

        [ActionName("mem.blocks"), HttpGet]
        public IHttpActionResult Mem_Blocks()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Block_GetList(); });
        }

        [ActionName("mem.clear"), HttpGet]
        public IHttpActionResult Mem_Clear()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IMem>().Clear(); });
        }
    }
}