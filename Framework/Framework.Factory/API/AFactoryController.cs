// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;
using System.Web.Http;

namespace Framework.Factory.API
{
    public abstract class AFactoryController : AController
    {
        //
        // HUB
        //

        [ActionName("hub.loaded"), HttpGet]
        public IHttpActionResult HUB_GetLoaded()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetListOfLoaded(); });
        }

        [ActionName("hub.instances"), HttpGet]
        public IHttpActionResult HUB_GetInstances()
        {
            return ApplyAndReturn(() => { return Scope.Hub.GetListOfInstances(); });
        }
    }
}