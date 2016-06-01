// ============================================================================
// Project: Framework
// Name/Class: Startup
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 08/Mar/2016
// Company: Cybermap
// Description: Application startup class.
// ============================================================================

using Framework.Configuration.API;
using Owin;
using System;

namespace Framework.Configuration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //
            // Initialize framework services.
            //

            Factory.API.Runtime.Init(app);

            //
            // Set a new data directory path.
            //

            AppDomain.CurrentDomain.SetData("DataDirectory", Factory.API.Runtime.Hub.GetUnique<IHost>().GetAbsolutePhysicalPath("Data\\DB\\"));

            //
            // Boot application.
            //

            Factory.API.Runtime.Hub.GetUnique<IStartup>().Startup(app);
        }
    }
}