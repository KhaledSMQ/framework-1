// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Forms.Api;
using System.Web.Http;

namespace Framework.Forms.Patterns
{
    public abstract class AController : Core.Patterns.AController
    {
        //
        // TEMPLATE-ACCESS-LAYER
        // Entry points for template manipulation.
        //

        [ActionName("template.import"), HttpPost, HttpPut]
        public IHttpActionResult Template_Import()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Template_Import(Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("template.get"), HttpGet, HttpPost]
        public IHttpActionResult Template_Get([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Template_Get(id); });
        }

        [ActionName("template.list"), HttpGet, HttpPost]
        public IHttpActionResult Template__List()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Template_GetList(); });
        }

        [ActionName("template.update"), HttpPost, HttpPut]
        public IHttpActionResult Template_Update()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Template_Update(Request.Content.ReadAsStringAsync().Result); });
        }

        [ActionName("template.delete"), HttpDelete, HttpPost, HttpPut]
        public IHttpActionResult Template_Delete([FromUri] string id)
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetUnique<IStore>().Template_Delete(id); });
        }
    }
}