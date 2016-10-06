// ============================================================================
// Project: Framework
// Name/Class: IoCPageHandlerFactory
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 6/Oct/2016
// Company: Coop4Creativity
// Description: Page handler resolver for dependencies.
// ============================================================================

using System.Web;
using System.Web.UI;

namespace Framework.App.Runtime
{
    public class IoCPageHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext httpCtx, string requestType, string virtualPath, string path)
        {
            return Inject(base.GetHandler(httpCtx, requestType, virtualPath, path));
        }

        private static IHttpHandler Inject(IHttpHandler page)
        {
            if (null != page && page is Framework.Web.Controls.Page)
            {
                ((Web.Controls.Page)page).Container = Manager.Container;
            }

            return page;
        }
    }
}
