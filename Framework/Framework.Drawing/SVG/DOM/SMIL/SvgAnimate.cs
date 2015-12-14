using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Drawing.SVG.DOM.Basic_Shapes;

namespace Framework.Drawing.SVG.DOM
{
    [SvgElement("animate")]
    public class SvgAnimate : SvgElement
    {
        private string _attrName;
        private string _attrType;
        private object _from;
        private object _to;
        private string _begin;
        private string _dur;
        private string _fill;
        private string _type;

        [SvgAttribute("attributeName")]
        public string AttributeName
        {
            get { return this._attrName; }
            set { this._attrName = value; }
        }

        [SvgAttribute("attributeType")]
        public string AttributeType
        {
            get { return this._attrType; }
            set { this._attrType = value; }
        }

        [SvgAttribute("from")]
        public object From
        {
            get { return this._from; }
            set { this._from = value; }
        }

        [SvgAttribute("to")]
        public object To
        {
            get { return this._to; }
            set { this._to = value; }
        }

        [SvgAttribute("begin")]
        public string Begin
        {
            get { return this._begin; }
            set { this._begin = value; }
        }

        [SvgAttribute("type")]
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        [SvgAttribute("dur")]
        public string Duration
        {
            get { return this._dur; }
            set { this._dur = value; }
        }

        [SvgAttribute("fill")]
        public string Fill
        {
            get { return this._fill; }
            set { this._fill = value; }
        }

    }
}
