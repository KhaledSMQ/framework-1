// ============================================================================
// Project: Toolkit - Apps
// Name/Class: UserControl
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base user control definition.
// ============================================================================

using Framework.Core;
using Framework.Core.API;
using System;

namespace Framework.Web.UI
{
    public class UserControl : System.Web.UI.UserControl
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //

        public IHub Hub { get; set; }

        public IScope Scope { get; protected set; }

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

            //
            // Set the context scope for the control.
            //

            Scope = Hub.GetUnique<IScope>().New();
        }
    }
}
