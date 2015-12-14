using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Drawing.SVG.DOM;

namespace Framework.Drawing.Drawing.SVG.DOM.Document_Structure
{
    [SvgElement("style")]
    public class SvgStyle : SvgElement
    {
        private string _type = "text/css";

        /// <summary>
        /// Gets or sets the text to be rendered.
        /// </summary>
        public virtual string Text
        {
            get { return base.Content; }
            set { base.Content = value; }
        }

        [SvgAttribute("type")]
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Text;
        }
    }
}
