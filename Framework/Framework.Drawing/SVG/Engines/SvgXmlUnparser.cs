using Framework.Drawing.SVG.DOM;
using System.Xml.Linq;

namespace Framework.Drawing.SVG.Engines
{
    public static class SvgXmlUnparser
    {
        public static XDocument Run(SvgDocument document)
        {
            return document.UnparseToXmlDocument();
        }
    }
}
