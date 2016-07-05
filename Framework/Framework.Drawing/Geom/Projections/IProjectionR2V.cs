// ============================================================================
// Project: Framework
// Name/Class: IProjectionR2V
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Real to Virtual projection.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionR2V : IXmlReady
    {
        double TransformR2VX(double x);
        double TransformR2VY(double y);

        double TransformR2VW(double x);
        double TransformR2VH(double y);

        void TransformR2VXY(double x, double y, out double outX, out double outY);
        void TransformR2VWH(double w, double h, out double outW, out double outH);

        dRect TransformR2V(dRect shape);
    }
}
