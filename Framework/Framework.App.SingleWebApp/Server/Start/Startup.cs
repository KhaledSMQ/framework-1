// ============================================================================
// Project: Framework
// Name/Class: Startup
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap
// Description: Application startup class.
// ============================================================================

using Framework.Configuration.API.Interface;
using Framework.Data.API.Interface;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(Framework.App.SingleWebApp.Server.Start.Startup))]

namespace Framework.App.SingleWebApp.Server.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //
            // Initialize framework services.
            //

            Factory.Runtime.Init(app);

            //
            // Set a new data directory path.
            //

            AppDomain.CurrentDomain.SetData("DataDirectory", Factory.Runtime.Hub.GetUnique<IHost>().GetAbsolutePhysicalPath("Data\\DB\\"));

            //
            // Boot application.
            //

            Factory.Runtime.Hub.GetUnique<IStartup>().Startup(app);

            //
            // Initialize data clusters.
            // 

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}