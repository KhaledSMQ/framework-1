// ============================================================================
// Project: Framework
// Name/Class: Control
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 15/Abr/2014
// Company: Coop4Creativity
// Description: Base control definition.
// ============================================================================

using Framework.Factory.API;
using System;

namespace Framework.Web.View
{
    public class Control : System.Web.UI.Control
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

            Scope = Factory.API.Runtime.Hub.GetUnique<IScope>().New();
        }
    }
}
