using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Drawing.SVG.DOM.Text
{
    /// <summary>
    /// Text anchor is used to align (start-, middle- or end-alignment) a string of text relative to a given point.
    /// </summary>
    public enum SvgTextAnchor
    {
        none,
        /// <summary>
        /// The rendered characters are aligned such that the start of the text string is at the initial current text position.
        /// </summary>
        start,
        /// <summary>
        /// The rendered characters are aligned such that the middle of the text string is at the current text position.
        /// </summary>
        middle,
        /// <summary>
        /// The rendered characters are aligned such that the end of the text string is at the initial current text position.
        /// </summary>
        end
    }
}