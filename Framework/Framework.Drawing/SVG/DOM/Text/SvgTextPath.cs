using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Framework.Drawing.SVG.DOM.Text
{
    [SvgElement("textPath")]
    public class SvgTextPath : SvgText
    {
        private string _referencedElement;

        [SvgAttribute("href")]
        public virtual string ReferencedElement
        {
            get { return this._referencedElement; }
            set { this._referencedElement = value; }
        }
    }
}
