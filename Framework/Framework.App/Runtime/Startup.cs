﻿// ============================================================================
// Project: Framework
// Name/Class: Startup
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description: Application startup class.
// ============================================================================

using Framework.Core.Api;
using Owin;
using System;

namespace Framework.App.Runtime
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //
            // Initialize framework.
            //

            Manager.Init(app);

            //
            // Set a new data directory path.
            //

            AppDomain.CurrentDomain.SetData("DataDirectory", Manager.Host.GetAbsolutePhysicalPath("Data\\DB\\"));

            //
            //
            //


        }
    }
}