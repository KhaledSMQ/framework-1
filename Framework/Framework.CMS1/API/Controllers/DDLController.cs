// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Toolkit.Apps.Web.Framework.Controllers;
using Framework.CMS1.Api.Interface;
using Framework.CMS1.Api.Query;
using Framework.CMS1.Model;
using Framework.CMS1.Model.Entities;
using Framework.CMS1.Model.Types;
using Framework.CMS1.Model.Views;

namespace Framework.CMS1.Api.Controllers
{
    public class CmsDDLController : AServiceWrapperController<IDML>
    {
        //
        // CLUSTER
        //

        [ActionName("cluster-create")]
        [HttpPost]
        public IHttpActionResult Cluster_Create([FromBody] Cluster item)
        {
            return Ok(Srv.Create<Cluster, int>(item, Ctx.Services.Get<ICluster>(), GetApiContext()));
        }

        [ActionName("cluster-get")]
        [HttpGet]
        public IHttpActionResult Cluster_Get(int id)
        {
            return Ok(Srv.Get<Cluster, int>(from => from.Visible().ByID(id), Ctx.Services.Get<ICluster>(), GetApiContext()));
        }

        [ActionName("cluster-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Cluster_GetByRef(string id)
        {
            return Ok(Srv.Get<Cluster, int>(from => from.Visible().ByRef(id), Ctx.Services.Get<ICluster>(), GetApiContext()));
        }

        [ActionName("cluster-list")]
        [HttpGet]
        public IHttpActionResult Cluster_List()
        {
            return Ok(Srv.GetList<Cluster, int>(from => from.Visible(), Ctx.Services.Get<ICluster>(), GetApiContext()));
        }

        [ActionName("cluster-list-of-entities")]
        [HttpGet]
        public IHttpActionResult Cluster_ListOfEntities(string id)
        {
            return Ok(Srv.GetList<Entity, int>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        //
        // ENTITY
        //

        [ActionName("entity-create")]
        [HttpPost]
        public IHttpActionResult Entity_Create([FromBody] Entity item)
        {
            return Ok(Srv.Create<Entity, int>(item, Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        [ActionName("entity-get")]
        [HttpGet]
        public IHttpActionResult Entity_Get(int id)
        {
            return Ok(Srv.Get<Entity, int>(from =>
                from.ByID(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        [ActionName("entity-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Entity_GetByRef(string id)
        {
            return Ok(Srv.Get<Entity, int>(from =>
                from.ByRef(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        [ActionName("entity-list")]
        [HttpGet]
        public IHttpActionResult Entity_List()
        {
            return Ok(Srv.GetList<Entity, int>(from => from.Visible(), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        [ActionName("entity-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult Entity_ListByCluster(string id)
        {
            return Ok(Srv.GetList<Entity, int>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        //
        // VIEW
        //

        [ActionName("view-create")]
        [HttpPost]
        public IHttpActionResult View_Create([FromBody] View item)
        {
            return Ok(Srv.Create<View, int>(item, Ctx.Services.Get<IView>(), GetApiContext()));
        }

        [ActionName("view-get")]
        [HttpGet]
        public IHttpActionResult View_Get(int id)
        {
            return Ok(Srv.Get<View, int>(from => from.Visible().ByID(id), Ctx.Services.Get<IView>(), GetApiContext()));
        }

        [ActionName("view-get-by-ref")]
        [HttpGet]
        public IHttpActionResult View_GetByRef(string id)
        {
            return Ok(Srv.Get<View, int>(from => from.Visible().ByRef(id), Ctx.Services.Get<IView>(), GetApiContext()));
        }

        [ActionName("view-list")]
        [HttpGet]
        public IHttpActionResult View_List()
        {
            return Ok(Srv.GetList<View, int>(from => from.Visible(), Ctx.Services.Get<IView>(), GetApiContext()));
        }

        [ActionName("view-list-by-entity")]
        [HttpGet]
        public IHttpActionResult View_ListByEntity(string id)
        {
            return Ok(Srv.GetList<Entity, int>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Services.Get<IEntity>(), GetApiContext()));
        }

        //
        // CONTENT-TYPE
        //

        [ActionName("ctype-create")]
        [HttpPost]
        public IHttpActionResult ContentType_Create([FromBody] ContentType item)
        {
            return Ok(Srv.Create<ContentType, int>(item, Ctx.Services.Get<IContentType>(), GetApiContext()));
        }

        [ActionName("ctype-get")]
        [HttpGet]
        public IHttpActionResult ContentType_Get(int id)
        {
            return Ok(Srv.Get<ContentType, int>(from => from.Visible().ByID(id), Ctx.Services.Get<IContentType>(), GetApiContext()));
        }

        [ActionName("ctype-get-by-ref")]
        [HttpGet]
        public IHttpActionResult ContentType_GetByRef(string id)
        {
            return Ok(Srv.Get<View, int>(from => from.Visible().ByRef(id), Ctx.Services.Get<IView>(), GetApiContext()));
        }

        [ActionName("ctype-list")]
        [HttpGet]
        public IHttpActionResult ContentType_List()
        {
            return Ok(Srv.GetList<ContentType, int>(from => from.Visible(), Ctx.Services.Get<IContentType>(), GetApiContext()));
        }

        [ActionName("ctype-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult ContentType_ListByCluster(string id)
        {
            return Ok(Srv.GetList<ContentType, int>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Ctx.Services.Get<IContentType>(), GetApiContext()));
        }
    }
}