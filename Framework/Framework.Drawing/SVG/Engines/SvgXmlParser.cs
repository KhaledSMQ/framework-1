using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Framework.Drawing.SVG.DOM;
using System.Xml;

namespace Framework.Drawing.SVG.Engines
{
    public static class SvgXmlParser
    {
        public static SvgDocument Run(XElement elm)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(elm.Document.ToString());
            return SvgDocument.Open(doc);
        }
    }
}
