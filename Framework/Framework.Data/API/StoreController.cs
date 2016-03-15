// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Framework.Data.API
{
    public class StoreController : AController
    {
        [ActionName("entity.create")]
        [HttpPost]
        public IHttpActionResult Create([FromUri] string cluster, [FromUri] string entity)
        {
            return __RunCode(() =>
            {
                Type type = srvDataStore.GetEntityTypeByClusterAndName(cluster, entity);
                string json = Request.Content.ReadAsStringAsync().Result;
                object item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, json);
                return srvDataScope.Create(cluster, type, item);
            });
        }

        [ActionName("entity.query")]
        [HttpGet]
        public IHttpActionResult Query([FromUri] string cluster, [FromUri] string entity, [FromUri] string name)
        {
            return __RunCode(() =>
            {
                Type type = srvDataStore.GetEntityTypeByClusterAndName(cluster, entity);
                return srvDataScope.Query(cluster, type, name);
            });
        }


        [ActionName("entity.update")]
        [HttpPost]
        public IHttpActionResult Update([FromUri] string cluster, [FromUri] string entity)
        {
            return __RunCode(() =>
            {
                Type type = srvDataStore.GetEntityTypeByClusterAndName(cluster, entity);
                string json = Request.Content.ReadAsStringAsync().Result;
                object item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(type, json);
                return srvDataScope.Update(cluster, type, item);
            });
        }

        //
        // Initialize the store controller.
        // Starts the data store and data scope for data access layer.
        //

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            srvDataStore = Scope.Hub.GetUnique<IDataStore>();
            srvDataScope = Scope.Hub.GetUnique<IDynamicStoreDataScope>();
        }

        //
        // HELPERS
        // Dependency services.
        //

        protected IDataStore srvDataStore = null;
        protected IDynamicStoreDataScope srvDataScope = null;
    }
}