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
    public class StoreController : AController
    {
        //
        // ENTITIES
        // Data Access Layer Entities.
        //

        [ActionName("entity.create"), HttpPost, HttpPut]
        public IHttpActionResult Entity_Create([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Entity_Create(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.query"), HttpGet]
        public IHttpActionResult Entity_Query([FromUri] string id, [FromUri] string name)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Entity_Query(id, name, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.update"), HttpPost]
        public IHttpActionResult Entity_Update([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Entity_Update(id, Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("entity.delete"), HttpDelete, HttpPost, HttpPut]
        public IHttpActionResult Entity_Delete([FromUri] string id)
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Entity_Delete(id, Request.Content.ReadAsStringAsync().Result); });
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        [ActionName("mem.domains"), HttpGet]
        public IHttpActionResult MemDomains()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetDomains(); });
        }

        [ActionName("mem.contexts"), HttpGet]
        public IHttpActionResult MemContexts()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetContexts(); });
        }

        [ActionName("mem.entities"), HttpGet]
        public IHttpActionResult MemEntities()
        {
            return Run(() => { return Scope.Hub.GetUnique<IStore>().Mem_GetEntities(); });
        }
    }
}