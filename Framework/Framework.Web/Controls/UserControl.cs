// ============================================================================
// Project: Toolkit - Apps
// Name/Class: UserControl
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base user control definition.
// ============================================================================

using Framework.Core;
using Framework.Core.Api;
using System;

namespace Framework.Web.Controls
{
    public class UserControl : System.Web.UI.UserControl
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //  

        public IContainer Container { get; set; }

        //
        // ONINIT
        // Event handler.
        //

        protected override void OnInit(EventArgs e)
        {
            //
            // Initialize base control.
            //

            base.OnInit(e);
        }
    }
}
