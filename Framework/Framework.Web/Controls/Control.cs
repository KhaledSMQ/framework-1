// ============================================================================
// Project: Framework
// Name/Class: Control
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
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
            GetContainerFromPage();
        }

        protected void GetContainerFromPage()
        {
            if (this.Page is Controls.Page)
            {
                Container = ((Controls.Page)this.Page).Container;
            }
        }
    }
}
