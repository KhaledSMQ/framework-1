// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Framework.CMS.Api.Interface;
using Framework.CMS.Api.Query;
using Framework.CMS.Model;
using Framework.CMS.Model.Entities;
using Framework.CMS.Model.Types;
using Framework.CMS.Model.Views;
using Framework.Factory.Patterns;

namespace Framework.CMS.Api.Controllers
{
    public class CmsDDLController : AControllerServiceWrapper<IDML>
    {
        //
        // CLUSTER
        //

        [ActionName("cluster-create")]
        [HttpPost]
        public IHttpActionResult Cluster_Create([FromBody] Cluster item)
        {
            return Ok(Srv.Create<Cluster>(item, Ctx.Hub.Get<ICluster>()));
        }

        [ActionName("cluster-get")]
        [HttpGet]
        public IHttpActionResult Cluster_Get(int id)
        {
            return Ok(Srv.Get<Cluster>(from => from.Visible().ByID(id), Ctx.Hub.Get<ICluster>()));
        }

        [ActionName("cluster-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Cluster_GetByRef(string id)
        {
            return Ok(Srv.Get<Cluster>(from => from.Visible().ByRef(id), Ctx.Hub.Get<ICluster>()));
        }

        [ActionName("cluster-list")]
        [HttpGet]
        public IHttpActionResult Cluster_List()
        {
            return Ok(Srv.GetList<Cluster>(from => from.Visible(), Ctx.Hub.Get<ICluster>()));
        }

        [ActionName("cluster-list-of-entities")]
        [HttpGet]
        public IHttpActionResult Cluster_ListOfEntities(string id)
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Hub.Get<IEntity>()));
        }

        //
        // ENTITY
        //

        [ActionName("entity-create")]
        [HttpPost]
        public IHttpActionResult Entity_Create([FromBody] Entity item)
        {
            return Ok(Srv.Create<Entity>(item, Ctx.Hub.Get<IEntity>()));
        }

        [ActionName("entity-get")]
        [HttpGet]
        public IHttpActionResult Entity_Get(int id)
        {
            return Ok(Srv.Get<Entity>(from =>
                from.ByID(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms), Ctx.Hub.Get<IEntity>()));
        }

        [ActionName("entity-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Entity_GetByRef(string id)
        {
            return Ok(Srv.Get<Entity>(from =>
                from.ByRef(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms), Ctx.Hub.Get<IEntity>()));
        }

        [ActionName("entity-list")]
        [HttpGet]
        public IHttpActionResult Entity_List()
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible(), Ctx.Hub.Get<IEntity>()));
        }

        [ActionName("entity-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult Entity_ListByCluster(string id)
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Hub.Get<IEntity>()));
        }

        //
        // VIEW
        //

        [ActionName("view-create")]
        [HttpPost]
        public IHttpActionResult View_Create([FromBody] View item)
        {
            return Ok(Srv.Create<View>(item, Ctx.Hub.Get<IView>()));
        }

        [ActionName("view-get")]
        [HttpGet]
        public IHttpActionResult View_Get(int id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByID(id), Ctx.Hub.Get<IView>()));
        }

        [ActionName("view-get-by-ref")]
        [HttpGet]
        public IHttpActionResult View_GetByRef(string id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByRef(id), Ctx.Hub.Get<IView>()));
        }

        [ActionName("view-list")]
        [HttpGet]
        public IHttpActionResult View_List()
        {
            return Ok(Srv.GetList<View>(from => from.Visible(), Ctx.Hub.Get<IView>()));
        }

        [ActionName("view-list-by-entity")]
        [HttpGet]
        public IHttpActionResult View_ListByEntity(string id)
        {
            return Ok(Srv.GetList<Entity>(from =>
                 from.Visible()
                .Include(item => item.Owner)
                .Where(item => item.Owner.Ref == id), Ctx.Hub.Get<IEntity>()));
        }

        //
        // CONTENT-TYPE
        //

        [ActionName("ctype-create")]
        [HttpPost]
        public IHttpActionResult ContentType_Create([FromBody] ContentType item)
        {
            return Ok(Srv.Create<ContentType>(item, Ctx.Hub.Get<IContentType>()));
        }

        [ActionName("ctype-get")]
        [HttpGet]
        public IHttpActionResult ContentType_Get(int id)
        {
            return Ok(Srv.Get<ContentType>(from => from.Visible().ByID(id), Ctx.Hub.Get<IContentType>()));
        }

        [ActionName("ctype-get-by-ref")]
        [HttpGet]
        public IHttpActionResult ContentType_GetByRef(string id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByRef(id), Ctx.Hub.Get<IView>()));
        }

        [ActionName("ctype-list")]
        [HttpGet]
        public IHttpActionResult ContentType_List()
        {
            return Ok(Srv.GetList<ContentType>(from => from.Visible(), Ctx.Hub.Get<IContentType>()));
        }

        [ActionName("ctype-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult ContentType_ListByCluster(string id)
        {
            return Ok(Srv.GetList<ContentType>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Hub.Get<IContentType>()));
        }
    }
}