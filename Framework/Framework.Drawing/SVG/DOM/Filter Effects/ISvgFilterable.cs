using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Drawing.SVG.DOM.Filter_Effects
{
    public interface ISvgFilterable
    {
        SvgFilter Filter { get; set; }
    }
}
