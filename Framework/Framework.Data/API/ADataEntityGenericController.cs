// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Extensions;
using Framework.Factory.Patterns;
using System.Linq;
using System.Web.Http;

namespace Framework.Data.API
{
    public abstract class DataEntityGenericController<TEntity> :
        AControllerServiceWrapper<IGenericClusterDataScope>
        where TEntity : class, IVisible
    { 
        [ActionName("create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] TEntity item)
        {
            return Ok(Srv.Create(item));
        }

        [ActionName("list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            return Ok(Srv.Queryable<TEntity>().Visible().ToList());
        }

        [ActionName("update")]
        [HttpPost]
        public IHttpActionResult Update([FromBody] TEntity item)
        {
            return Ok(Srv.Update(item));
        }
    }
}