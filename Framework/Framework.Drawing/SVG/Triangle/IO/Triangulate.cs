// Framework Library - Drawing
// Description: Svg Draw support for Framework library.
// Author(s): 
//    João Paulo Carreiro (joao.carreiro@coop4creativity.com)
// EDITED FROM ORIGINAL FILE:
// -----------------------------------------------------------------------
// <copyright file="SvgImage.cs" company="">
// Christian Woltering, Triangle.NET, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

namespace Framework.Drawing.SVG.Triangle.IO
{
    using System;
    using System.IO;
    using System.Text;
    using Framework.Drawing.SVG.Triangle;
    using Framework.Drawing.SVG.Triangle.Data;
    using Framework.Drawing.SVG.DOM;
    using Framework.Drawing.SVG.DOM.Document_Structure;
    using Framework.Drawing.SVG.DOM.Paths;
    using System.Drawing;
    using Framework.Core.Extensions;
    using Framework.Drawing.SVG.DOM.Pathing;
    using System.Collections.Generic;

    /// <summary>
    /// Writes a mesh to a SVG.
    /// </summary>
    public class Triangulate
    {
        float scale = 1f;
        SvgColourConverter ColourConvert = new SvgColourConverter();

        /// <summary>
        /// Export the mesh to SVG format.
        /// </summary>
        /// <param name="mesh">The current mesh.</param>
        public SvgGroup Export(Mesh mesh)
        {
            SvgGroup docGroup = new SvgGroup();
            SvgGroup groupTriangles = DrawTriangles(mesh);
            SvgGroup groupSegments = DrawSegments(mesh);

            docGroup.Children.Add(groupSegments);
            docGroup.Children.Add(groupTriangles);

            return docGroup;
        }
        /// <summary>
        /// Draw Triangles in the shape
        /// </summary>
        /// <param name="mesh">the current mesh</param>
        /// <returns></returns>
        public SvgGroup DrawTriangles(Mesh mesh)
        {
            SvgGroup group = new SvgGroup();
            SvgPath path;

            Vertex v1, v2, v3;
            double x1, y1, x2, y2, x3, y3;

            foreach (var tri in mesh.Triangles)
            {
                path = new SvgPath();

                v1 = tri.GetVertex(0);
                v2 = tri.GetVertex(1);
                v3 = tri.GetVertex(2);

                x1 = scale * v1.X;
                y1 = scale * v1.Y;
                x2 = scale * v2.X;
                y2 = scale * v2.Y;
                x3 = scale * v3.X;
                y3 = scale * v3.Y;

                path.PathData.Add(new SvgMoveToSegment(new PointF((float)x1, (float)y1)));
                path.PathData.Add(new SvgLineSegment(new PointF((float)x1, (float)y1), new PointF((float)x2, (float)y2)));
                path.PathData.Add(new SvgLineSegment(new PointF((float)x2, (float)y2), new PointF((float)x3, (float)y3)));
                path.PathData.Add(new SvgClosePathSegment());

                group.Children.Add(path);
            }

            return group;
        }
        /// <summary>
        /// Draw Segments in the shape
        /// </summary>
        /// <param name="mesh">the current shape</param>
        /// <returns></returns>
        public SvgGroup DrawSegments(Mesh mesh)
        {
            SvgGroup group = new SvgGroup();
            SvgPath path;

            double x1, y1, x2, y2;

            foreach (var seg in mesh.Segments)
            {
                path = new SvgPath();

                x1 = scale * seg.GetVertex(0).X;
                y1 = scale * seg.GetVertex(0).Y;
                x2 = scale * seg.GetVertex(1).X;
                y2 = scale * seg.GetVertex(1).Y;

                path.PathData.Add(new SvgMoveToSegment(new PointF((float)x1, (float)y1)));
                path.PathData.Add(new SvgLineSegment(new PointF((float)x1, (float)y1), new PointF((float)x2, (float)y2)));
                path.PathData.Add(new SvgClosePathSegment());

                group.Children.Add(path);
            }

            return group;
        }
    }
}
