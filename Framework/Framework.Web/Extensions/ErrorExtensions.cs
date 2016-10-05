// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Extensions;
using System;
using System.Diagnostics;

namespace Framework.Web.Extensions
{
    public static class ErrorExtensions
    {
        //
        // Generate a HTML code fragment for an exception
        //

        public static string GenerateHtmlErrorMessage(this Exception ex)
        {
            // exception
            string html = "<div class=\"exception\">";

            // error message
            html += "<div class=\"msg\">" + ex.Message + "</div>";

            // trace
            html += "<div class=\"trace\">";

            StackTrace st = new StackTrace(ex, true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                StackFrame sf = st.GetFrame(i);

                // frame
                html += "<div class=\"frame\">";

                // method name
                html += "<div class=\"method\">" + sf.GetMethod() + "</div>";

                // file and line 
                if (sf.GetFileName().IsNotNullAndEmpty())
                {
                    html += "<div class=\"file\">" + sf.GetFileName() + "[" + sf.GetFileLineNumber() + "]" + "</div>";
                }

                // frame
                html += "</div>";
            }

            // trace
            html += "</div>";

            // exception
            html += "</div>";

            return html;
        }
    }
}
