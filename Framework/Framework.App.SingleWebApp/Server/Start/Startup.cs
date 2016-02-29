// ============================================================================
// Project: Framework
// Name/Class: Startup
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap
// Description: Application startup class.
// ============================================================================

using Framework.Data.API.Interface;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Framework.App.SingleWebApp.Server.Start.Startup))]

namespace Framework.App.SingleWebApp.Server.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //
            // Initialize framework services.
            //

            Factory.Runtime.Manager.Init(app);
            Data.Runtime.Manager.Init(app);

            IStore srvDataStore = Factory.Runtime.Manager.Hub.GetUnique<IStore>();
            // srvDataStore.GetDataSet<>();

            //
            // Set a new data directory path.
            //

            // string dataDirectory = Path.Combine(Framework.Apps.Web.Framework.Context.Host.AppContext.Config.Host.BasePhysicalFolder, "_data\\_db\\");
            // AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }
    }
}