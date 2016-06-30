// ============================================================================
// Project: Toolkit
// Name/Class: ErrorExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 29/July/2013
// Company: Coop4Creativity
// Description: Extensions methods for Error handling in a ASP.NET environment
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

        public static string GenerateHTMLErrorMessage(this Exception ex)
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
                if (sf.GetFileName().isNotNullAndEmpty())
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
