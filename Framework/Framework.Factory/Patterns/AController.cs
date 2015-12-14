// ============================================================================
// Project: Framework
// Name/Class: AController
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base Api controller class.
// ============================================================================

using System.Web.Http;
using System.Web.Http.Controllers;

namespace Framework.Factory.Patterns
{
    public abstract class AController : ApiController
    {
        //
        // PROPERTIES
        // Page properties for subclasses.
        //

        public IScope Ctx { get; private set; }

        //
        // CONSTRUCTORS
        //

        public AController() : base() { }

        //
        // INIT
        // Controller initialization.
        //

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }
    }
}
