// ============================================================================
// Project: FRamework
// Name/Class: Page
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base page definition.
// ============================================================================

using Framework.Factory.Patterns;
using System;

namespace Framework.Web.View
{
    public class Page : System.Web.UI.Page
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //

        public IScope Ctx { get; protected set; }

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
            // Get the context for the control.
            //

            Ctx = Framework.Factory.Runtime.Manager.Get();
        }
    }
}
