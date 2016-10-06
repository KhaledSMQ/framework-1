// ============================================================================
// Project: Framework
// Name/Class: Parsing
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Unparsing utilities.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using Framework.Core.Extensions;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Engines
{
    public static class Unparsing
    {
        public static string UnparseRectD(dRect shape)
        {
            return "x:" + shape.X + ";" + "y:" + shape.Y + ";" + "w:" + shape.W + ";" + "h:" + shape.H;
        }
    }
}
