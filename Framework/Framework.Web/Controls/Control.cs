// ============================================================================
// Project: Framework
// Name/Class: Control
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 15/Abr/2014
// Company: Coop4Creativity
// Description: Base control definition.
// ============================================================================

using Framework.Core.Api;
using System;

namespace Framework.Web.Controls
{
    public class Control : System.Web.UI.Control
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
            // Get the context for the control.
            //

            Scope = Hub.GetUnique<IScope>().New();
        }
    }
}
