// ============================================================================
// Project: Framework
// Name/Class: Error
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/Mar/2016
// Company: Coop4Creativity
// Description: Display an error message.
// ============================================================================

using System;
using System.Web.UI;

namespace Framework.Web.Controls
{
    [ToolboxData("<{0}:Error runat=\"server\"></{0}:Error>")]
    public class Error : Control
    {
        //
        // PROPERTIES
        //

        public string CssClass { get; set; }

        public Exception Exception { get; set; }

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
