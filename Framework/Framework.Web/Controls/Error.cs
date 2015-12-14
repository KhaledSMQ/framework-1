// ============================================================================
// Project: Toolkit - Apps
// Name/Class: AppLogo
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 06/Jun/2014
// Company: Cybermap Lta.
// Description: Display the application logo as an image tag.
// ============================================================================

using System;
using System.Web.UI;

namespace Framework.Web.Controls
{
    [ToolboxData("<{0}:Error runat=\"server\"></{0}:Error>")]
    public class Error : Framework.Web.View.Control
    {
        //
        // PROPERTIES
        //

        public string CssClass { get; set; }

        public Exception Exception { get; set; }

        //
        // CONSTRUCTORS
        //

        public Error() : base() { }

        //
        // ON-INIT
        // Event handler
        //

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div class=\"error\">");
            writer.Write("<div class=\"message\">");
            writer.Write(Exception.Message);
            writer.Write("</div>");
            writer.Write("<div class=\"trace\">");
            writer.Write(Exception.StackTrace);
            writer.Write("</div>");
            writer.Write("</div>");
        }
    }
}
