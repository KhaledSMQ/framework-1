// ============================================================================
// Project: Framework
// Name/Class: AControllerServiceWrapper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Service wrapper base controller.
// ============================================================================


namespace Framework.Factory.Patterns
{
    public abstract class AControllerServiceWrapper<TSrv> : AController
        where TSrv : ICommon
    {
        //
        // Service reference.
        //

        public TSrv Srv { get; set; }

        //
        // INIT
        //

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            //
            // Base controller initialization.
            //

            base.Initialize(controllerContext);

            //
            // Service initialization.
            //

            Srv = Ctx.Hub.Get<TSrv>();
        }
    }
}