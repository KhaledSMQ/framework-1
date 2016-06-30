// ============================================================================
// Project: Framework
// Name/Class: IProjectionV2R
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Proportional to Virtual projection.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionP2V : IXmlReady
    {
        //
        // TRANSFORM: Proportional --> Virtual
        //

        double TransformP2VX(double x);
        double TransformP2VY(double y);

        double TransformP2VW(double x);
        double TransformP2VH(double y);

        void TransformP2VXY(double x, double y, out double outX, out double outY);
        void TransformP2VWH(double w, double h, out double outW, out double outH);

        dRect TransformP2V(dRect inShape);
    }
}
