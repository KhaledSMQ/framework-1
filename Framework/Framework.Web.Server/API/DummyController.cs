// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System.Web.Http;

namespace Framework.Web.Server.API
{
    public class DummyController : Factory.Patterns.AController
    {
        [ActionName("run"), HttpGet, HttpPost, HttpPut]
        public IHttpActionResult Run()
        {
            return ApplyNoReturn(() => { Scope.Hub.GetUnique<IDummyService>().Run(); });
        }
    }
}