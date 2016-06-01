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

namespace Framework.Factory.API
{
    public class FactoryController : AController
    {
        //
        // HUB
        //

        [ActionName("hub.loaded"), HttpGet]
        public IHttpActionResult HUB_GetLoaded()
        {
            return Run(() => { return Scope.Hub.GetListOfLoaded(); });
        }

        [ActionName("hub.instances"), HttpGet]
        public IHttpActionResult HUB_GetInstances()
        {
            return Run(() => { return Scope.Hub.GetListOfInstances(); });
        }
    }
}