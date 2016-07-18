// ============================================================================
// Project: FRamework
// Name/Class: Page
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base page definition.
// ============================================================================

using Framework.Core;
using Framework.Core.API;
using System;

namespace Framework.Web.UI
{
    public class Page : System.Web.UI.Page
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
            // Get the context for the control.
            //

            Scope = Manager.Hub.GetUnique<IScope>().New();
        }
    }
}
