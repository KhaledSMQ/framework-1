using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Framework.Drawing.SVG.DOM;
using System.Xml;
using System.IO;
using System.Drawing.Imaging;

namespace Framework.Drawing.SVG.Engines
{
    public static class Svg2Image
    {
        public static byte[] Run(SvgDocument document, ImageFormat format)
        {
            // Draw from svg document.
            MemoryStream Stream = new MemoryStream();
            document.Draw().Save(Stream, format);

            Stream.Position = 0;
            return Stream.ToArray();
        }
    }
}
