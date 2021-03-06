using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Framework.Drawing.SVG.DOM.Paths
{
    public sealed class SvgLineSegment : SvgPathSegment
    {
        public SvgLineSegment(PointF start, PointF end)
        {
            this.Start = start;
            this.End = end;
        }

        public override void AddToPath(System.Drawing.Drawing2D.GraphicsPath graphicsPath)
        {
            graphicsPath.AddLine(this.Start, this.End);
        }
    }
}