// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.API;
using Framework.Data.Model.Import;
using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Data.Patterns
{
    public abstract class ADataController : AController
    {
        //
        // SCHEMA-ACCESS-LAYER
        // Entry points for data definition layer.
        //

        [ActionName("schema.init"), HttpGet, HttpPost, HttpPut]
        public IHttpActionResult SCHEMA_InitCluster([FromUri] string id)
        {
            return ApplyNoReturn(() => { Scope.Hub.GetUnique<IStore>().Schema_Init(id); });
        }

        [ActionName("schema.import"), HttpPost, HttpPut]
        public IHttpActionResult SCHEMA_ImportCluster([FromBody] ImportCluster cluster)
        {
            return ApplyNoReturn(() => { Scope.Hub.GetUnique<IStore>().Schema_Import(cluster); });
        }

        //
        // DATA-ACCESS-LAYER
        // Entry points for data manipulation.
        //

        [ActionName("dal.create"), HttpPost, HttpPut]
        public IHttpActionResult DAL_Create([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Dal_Create(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("dal.query"), HttpGet]
        public IHttpActionResult DAL_Query([FromUri] string id, [FromUri] string name)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Dal_Query(id, name, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("dal.update"), HttpPost]
        public IHttpActionResult DAL_Update([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Dal_Update(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("dal.delete"), HttpDelete, HttpPost, HttpPut]
        public IHttpActionResult DAL_Delete([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Dal_Delete(id, Request.Content.ReadAsStringAsync().Result); });
        }

        //
        // DIAGNOSTICS
        //

        [ActionName("mem.dump"), HttpGet]
        public IHttpActionResult Mem_Dump()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_Dump(); });
        }

        [ActionName("mem.clusters"), HttpGet]
        public IHttpActionResult Mem_Clusters()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetClusters(); });
        }

        [ActionName("mem.contexts"), HttpGet]
        public IHttpActionResult Mem_Contexts()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetContexts(); });
        }

        [ActionName("mem.entities"), HttpGet]
        public IHttpActionResult Mem_Entities()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetEntities(); });
        }

        [ActionName("mem.models"), HttpGet]
        public IHttpActionResult Mem_Models()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetModels(); });
        }

        [ActionName("mem.queries"), HttpGet]
        public IHttpActionResult Mem_Queries()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetQueries(); });
        }
    }
}