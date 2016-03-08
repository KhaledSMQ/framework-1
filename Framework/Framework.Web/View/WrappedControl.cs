// ============================================================================
// Project: Framework - Apps
// Name/Class: Control
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 15/Abr/2014
// Company: Cybermap Lta.
// Description: Base control definition.
// ============================================================================

using Framework.Web.Controls;
using System;
using System.Web.UI;

namespace Framework.Web.View
{
    public class WrappedControl : Framework.Web.View.Control
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //

        //
        // Wrapped Event handlers
        // To be overridden by control instances.
        //

        protected virtual void _OnInit(EventArgs e) { }

        protected virtual void _OnLoad(EventArgs e) { }

        protected virtual void _OnPreRender(EventArgs e) { }

        protected virtual void _Render(HtmlTextWriter writer) { }

        protected virtual void _OnUnload(EventArgs e) { }

        //
        // EVENT-HANLDERS
        // Wrappers
        //

        protected override void OnInit(EventArgs e)
        {
            _RunSafeCode(() =>
            {
                base.OnInit(e);
                _OnInit(e);
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            _RunSafeCode(() =>
            {
                base.OnLoad(e);
                _OnLoad(e);
            });
        }

        protected override void OnPreRender(EventArgs e)
        {
            _RunSafeCode(() =>
            {
                base.OnPreRender(e);
                _OnPreRender(e);
            });
        }

        protected override void Render(HtmlTextWriter writer)
        {
            _RunSafeCodeInRender(writer, () =>
            {
                base.Render(writer);
                _Render(writer);
            });
        }

        protected override void OnUnload(EventArgs e)
        {
            _RunSafeCode(() =>
            {
                base.OnUnload(e);
                _OnUnload(e);
            });
        }

        //
        // HELPERS
        //

        private void _RunSafeCode(Action method)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                Error errControl = (Error)Page.LoadControl(typeof(Error), null);
                errControl.Exception = ex;
                Controls.Add(errControl);
            }
        }

        private void _RunSafeCodeInRender(HtmlTextWriter writer, Action method)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                writer.Write("<div class=\"error\">");
                writer.Write("<div class=\"message\">");
                writer.Write(ex.Message);
                writer.Write("</div>");
                writer.Write("<div class=\"trace\">");
                writer.Write(ex.StackTrace);
                writer.Write("</div>");
                writer.Write("</div>");
            }
        }
    }
}