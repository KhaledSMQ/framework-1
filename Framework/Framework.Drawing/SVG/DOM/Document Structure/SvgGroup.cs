using System.Drawing;
using Framework.Drawing.SVG.DOM.Basic_Shapes;
using Framework.Drawing.SVG.DOM.Pathing;

namespace Framework.Drawing.SVG.DOM.Document_Structure
{
    /// <summary>
    /// An element used to group SVG shapes.
    /// </summary>
    [SvgElement("g")]
    public class SvgGroup : SvgVisualElement
    {
        public SvgGroup()
        {
        }

        /// <summary>
        /// Gets or sets the fill.
        /// </summary>
        /// <value>The fill.</value>
        [SvgAttribute("fill")]
        public override SvgPaintServer Fill
        {
            get { return (this.Attributes["Fill"] == null) ? null : (SvgPaintServer)this.Attributes["Fill"]; }
            set { this.Attributes["Fill"] = value; }
        }

        /// <summary>
        /// Gets the <see cref="GraphicsPath"/> for this element.
        /// </summary>
        /// <value></value>
        public override System.Drawing.Drawing2D.GraphicsPath Path
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the bounds of the element.
        /// </summary>
        /// <value>The bounds.</value>
        public override System.Drawing.RectangleF Bounds
        {
            get { return new System.Drawing.RectangleF(); }
        }
        /// <summary>
        /// Renders the <see cref="SvgElement"/> and contents to the specified <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="graphics">The <see cref="Graphics"/> object to render to.</param>
        protected override void Render(SvgRenderer renderer)
        {
            this.PushTransforms(renderer);
            this.SetClip(renderer);
            base.RenderChildren(renderer);
            this.ResetClip(renderer);
            this.PopTransforms(renderer);
        }
    }
}