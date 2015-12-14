using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Framework.Drawing.SVG.DOM.Paths
{
    public class SvgMoveToSegment : SvgPathSegment
    {
        public SvgMoveToSegment(PointF moveTo)
        {
            this.Start = moveTo;
            this.End = moveTo;
        }

        public override void AddToPath(System.Drawing.Drawing2D.GraphicsPath graphicsPath)
        {
            graphicsPath.StartFigure();
        }
    }
}
