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
using Framework.Data.Extensions;
using Framework.Factory.Patterns;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Framework.CMS.API
{
    public class CmsDDLController : AControllerServiceWrapper<IGenericClusterDataScope>
    {
        //
        // CLUSTER
        //

        [ActionName("cluster-create")]
        [HttpPost]
        public IHttpActionResult Cluster_Create([FromBody] Cluster item)
        {
            return Ok(Srv.Create(item));
        }

        [ActionName("cluster-get")]
        [HttpGet]
        public IHttpActionResult Cluster_Get(int id)
        {
            return Ok(Srv.Queryable<Cluster>()
                    .Visible()
                    .ByID(id)
                    .SingleOrDefault());
        }

        [ActionName("cluster-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Cluster_GetByRef(string id)
        {
            return Ok(Srv.Queryable<Cluster>()
                    .Visible()
                    .ByRef(id)
                    .SingleOrDefault());
        }

        [ActionName("cluster-list")]
        [HttpGet]
        public IHttpActionResult Cluster_List()
        {
            return Ok(Srv.Queryable<Cluster>()
                    .Visible()
                    .ToList());
        }

        [ActionName("cluster-list-of-entities")]
        [HttpGet]
        public IHttpActionResult Cluster_ListOfEntities(string id)
        {
            return Ok(Srv.Queryable<Entity>()
                    .Visible()
                    .Include(item => item.Owner)
                    .Where(item => item.Owner.Ref == id)
                    .ToList());
        }

        //
        // ENTITY
        //

        [ActionName("entity-create")]
        [HttpPost]
        public IHttpActionResult Entity_Create([FromBody] Entity item)
        {
            return Ok(Srv.Create(item));
        }

        [ActionName("entity-get")]
        [HttpGet]
        public IHttpActionResult Entity_Get(int id)
        {
            return Ok(Srv.Queryable<Entity>()
                    .ByID(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms)
                    .SingleOrDefault());
        }

        [ActionName("entity-get-by-ref")]
        [HttpGet]
        public IHttpActionResult Entity_GetByRef(string id)
        {
            return Ok(Srv.Queryable<Entity>()
                    .ByRef(id)
                    .Include(e => e.Api)
                    .Include(e => e.Definition)
                    .Include(e => e.Views)
                    .Include(e => e.Schemas)
                    .Include(e => e.Forms)
                    .SingleOrDefault());
        }

        [ActionName("entity-list")]
        [HttpGet]
        public IHttpActionResult Entity_List()
        {
            return Ok(Srv.Queryable<Entity>()
                    .Visible()
                    .ToList());
        }

        [ActionName("entity-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult Entity_ListByCluster(string id)
        {
            return Ok(Srv.Queryable<Entity>()
                    .Visible()
                    .Include(item => item.Owner)
                    .Where(item => item.Owner.Ref == id)
                    .ToList());
        }

        //
        // VIEW
        //

        [ActionName("view-create")]
        [HttpPost]
        public IHttpActionResult View_Create([FromBody] View item)
        {
            return Ok(Srv.Create(item));
        }

        [ActionName("view-get")]
        [HttpGet]
        public IHttpActionResult View_Get(int id)
        {
            return Ok(Srv.Queryable<View>()
                    .Visible()
                    .ByID(id)
                    .SingleOrDefault());
        }

        [ActionName("view-get-by-ref")]
        [HttpGet]
        public IHttpActionResult View_GetByRef(string id)
        {
            return Ok(Srv.Queryable<View>()
                    .Visible()
                    .ByRef(id)
                    .SingleOrDefault());
        }

        [ActionName("view-list")]
        [HttpGet]
        public IHttpActionResult View_List()
        {
            return Ok(Srv.Queryable<View>()
                    .Visible()
                    .ToList());
        }

        [ActionName("view-list-by-entity")]
        [HttpGet]
        public IHttpActionResult View_ListByEntity(string id)
        {
            return Ok(Srv.Queryable<View>()
                    .Visible()
                    .Include(item => item.Owner)
                    .Where(item => item.Owner.Ref == id)
                    .ToList());
        }

        //
        // CONTENT-TYPE
        //

        [ActionName("ctype-create")]
        [HttpPost]
        public IHttpActionResult ContentType_Create([FromBody] ContentType item)
        {
            return Ok(Srv.Create(item));
        }

        [ActionName("ctype-get")]
        [HttpGet]
        public IHttpActionResult ContentType_Get(int id)
        {
            return Ok(Srv.Queryable<ContentType>()
                    .Visible()
                    .ByID(id)
                    .SingleOrDefault());
        }

        [ActionName("ctype-get-by-ref")]
        [HttpGet]
        public IHttpActionResult ContentType_GetByRef(string id)
        {
            return Ok(Srv.Queryable<ContentType>()
                    .Visible()
                    .ByRef(id)
                    .SingleOrDefault());
        }

        [ActionName("ctype-list")]
        [HttpGet]
        public IHttpActionResult ContentType_List()
        {
            return Ok(Srv.Queryable<ContentType>()
                    .Visible()
                    .SingleOrDefault());
        }

        [ActionName("ctype-list-by-cluster")]
        [HttpGet]
        public IHttpActionResult ContentType_ListByCluster(string id)
        {
            return Ok(Srv.Queryable<ContentType>()
                    .Visible()
                    .Include(item => item.Owner)
                    .Where(item => item.Owner.Ref == id)
                    .SingleOrDefault());
        }
    }
}