// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.CMS.Model;
using Framework.CMS.Model.Entities;
using Framework.CMS.Model.Types;
using Framework.CMS.Model.Views;
using Framework.Data.API;
using Framework.Web.Patterns;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Framework.CMS.API
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
            return Ok(Srv.Create(item, Scope.Hub.GetUnique<IDataScope>().GetDataSet<Cluster>()));
        }

        [ActionName("cluster-get")]
        [HttpGet]
        public IHttpActionResult Cluster_Get(int id)
        {
            return Ok(Srv.Get<Cluster>(from => from.Visible().ByID(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Cluster>()));
        }

        [ActionName("cluster-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Cluster_GetByRef(string id)
        {
            return Ok(Srv.Get<Cluster>(from => from.Visible().ByRef(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Cluster>()));
        }

        [ActionName("cluster-list")]
        [HttpGet]
        public IHttpActionResult Cluster_List()
        {
            return Ok(Srv.GetList<Cluster>(from => from.Visible(), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Cluster>()));
        }

        [ActionName("cluster-list-of-entities")]
        [HttpGet]
        public IHttpActionResult Cluster_ListOfEntities(string id)
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
        }

        //
        // ENTITY
        //

        [ActionName("entity-create")]
        [HttpPost]
        public IHttpActionResult Entity_Create([FromBody] Entity item)
        {
            return Ok(Srv.Create<Entity>(item, Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
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
                    .Include(e => e.Forms), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
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
                    .Include(e => e.Forms), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
        }

        [ActionName("entity-list")]
        [HttpGet]
        public IHttpActionResult Entity_List()
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible(), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
        }

        [ActionName("entity-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult Entity_ListByCluster(string id)
        {
            return Ok(Srv.GetList<Entity>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
        }

        //
        // VIEW
        //

        [ActionName("view-create")]
        [HttpPost]
        public IHttpActionResult View_Create([FromBody] View item)
        {
            return Ok(Srv.Create<View>(item, Scope.Hub.GetUnique<IDataScope>().GetDataSet<View>()));
        }

        [ActionName("view-get")]
        [HttpGet]
        public IHttpActionResult View_Get(int id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByID(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<View>()));
        }

        [ActionName("view-get-by-ref")]
        [HttpGet]
        public IHttpActionResult View_GetByRef(string id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByRef(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<View>()));
        }

        [ActionName("view-list")]
        [HttpGet]
        public IHttpActionResult View_List()
        {
            return Ok(Srv.GetList<View>(from => from.Visible(), Scope.Hub.GetUnique<IDataScope>().GetDataSet<View>()));
        }

        [ActionName("view-list-by-entity")]
        [HttpGet]
        public IHttpActionResult View_ListByEntity(string id)
        {
            return Ok(Srv.GetList<Entity>(from =>
                 from.Visible()
                .Include(item => item.Owner)
                .Where(item => item.Owner.Ref == id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<Entity>()));
        }

        //
        // CONTENT-TYPE
        //

        [ActionName("ctype-create")]
        [HttpPost]
        public IHttpActionResult ContentType_Create([FromBody] ContentType item)
        {
            return Ok(Srv.Create<ContentType>(item, Scope.Hub.GetUnique<IDataScope>().GetDataSet<ContentType>()));
        }

        [ActionName("ctype-get")]
        [HttpGet]
        public IHttpActionResult ContentType_Get(int id)
        {
            return Ok(Srv.Get<ContentType>(from => from.Visible().ByID(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<ContentType>()));
        }

        [ActionName("ctype-get-by-ref")]
        [HttpGet]
        public IHttpActionResult ContentType_GetByRef(string id)
        {
            return Ok(Srv.Get<View>(from => from.Visible().ByRef(id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<View>()));
        }

        [ActionName("ctype-list")]
        [HttpGet]
        public IHttpActionResult ContentType_List()
        {
            return Ok(Srv.GetList<ContentType>(from => from.Visible(), Scope.Hub.GetUnique<IDataScope>().GetDataSet<ContentType>()));
        }

        [ActionName("ctype-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult ContentType_ListByCluster(string id)
        {
            return Ok(Srv.GetList<ContentType>(from => from.Visible().Include(item => item.Owner).Where(item => item.Owner.Ref == id), Scope.Hub.GetUnique<IDataScope>().GetDataSet<ContentType>()));
        }
    }
}