using System;
using System.Drawing;
using Framework.Drawing.SVG.DOM.Basic_Shapes;

namespace Framework.Drawing.SVG.DOM.Pathing
{
    public sealed class SvgColourServer : SvgPaintServer
    {
        public SvgColourServer()
            : this(Color.Empty)
        {
        }

        public SvgColourServer(Color colour)
        {
            this._colour = colour;
        }

        private Color _colour;

        public Color Colour
        {
            get { return this._colour; }
            set { this._colour = value; }
        }

        public override Brush GetBrush(SvgVisualElement styleOwner, float opacity)
        {
            if (float.IsNaN(opacity))
            {
                opacity = 1;
            }

            int alpha = (int)((opacity * (this.Colour.A / 255)) * 255);
            Color colour = Color.FromArgb(alpha, this.Colour);

            return new SolidBrush(colour);
        }

        public override string ToString()
        {
            Color c = this.Colour;

            // Return the name if it exists
            if (c.IsKnownColor)
            {
                return c.Name;
            }

            // Return the hex value
            return String.Format("#{0}", c.ToArgb().ToString("x").Substring(2));
        }
    }
}
