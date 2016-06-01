// ============================================================================
// Project: Toolkit - Apps
// Name/Class: UserControl
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base user control definition.
// ============================================================================

using Framework.Factory.API;
using System;

namespace Framework.Web.View
{
    public class UserControl : System.Web.UI.UserControl
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //

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

            Scope = Factory.API.Runtime.Hub.GetUnique<IScope>().New();
        }
    }
}
