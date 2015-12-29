// ============================================================================
// Project: Framework
// Name/Class: Startup
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap
// Description: Application startup class.
// ============================================================================

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Framework.App.SingleWebApp.Server.Start.Startup))]

namespace Framework.App.SingleWebApp.Server.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //
            // Initialize framework services.
            //

            Data.Runtime.Manager.Init(app);
            Factory.Runtime.Manager.Init(app);

            //
            // Set a new data directory path.
            //

            // string dataDirectory = Path.Combine(Framework.Apps.Web.Framework.Context.Host.AppContext.Config.Host.BasePhysicalFolder, "_data\\_db\\");
            // AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/_api/user/login"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            //    Provider = new AuthServerProvider()
            //};

            ////
            //// Token Generation Method.
            ////

            //app.UseOAuthAuthorizationServer(OAuthServerOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}