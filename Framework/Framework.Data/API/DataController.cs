// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Data.API
{
    public class DataController : AController
    {
        //
        // DATA-ACCESS-LAYER
        //

        [ActionName("entity.create"), HttpPost, HttpPut]
        public IHttpActionResult DAL_Create([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().DAL_Create(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.query"), HttpGet]
        public IHttpActionResult DAL_Query([FromUri] string id, [FromUri] string name)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().DAL_Query(id, name, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.update"), HttpPost]
        public IHttpActionResult DAL_Update([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().DAL_Update(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.delete"), HttpDelete, HttpPost, HttpPut]
        public IHttpActionResult DAL_Delete([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().DAL_Delete(id, Request.Content.ReadAsStringAsync().Result); });
        }

        //
        // DIAGNOSTICS
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

        [ActionName("mem.clusters"), HttpGet]
        public IHttpActionResult Mem_Clusters()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetClusters(); });
        }

        [ActionName("mem.contexts"), HttpGet]
        public IHttpActionResult Mem_Contexts()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetContexts(); });
        }

        [ActionName("mem.entities"), HttpGet]
        public IHttpActionResult Mem_Entities()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetEntities(); });
        }

        [ActionName("mem.models"), HttpGet]
        public IHttpActionResult Mem_Models()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetModels(); });
        }

        [ActionName("mem.queries"), HttpGet]
        public IHttpActionResult Mem_Queries()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetQueries(); });
        }
    }
}