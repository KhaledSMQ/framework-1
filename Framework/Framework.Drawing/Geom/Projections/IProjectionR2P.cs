// ============================================================================
// Project: Framework
// Name/Class: IProjectionR2P
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Real to Proportional projection.
// ============================================================================

using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionR2P
    {
        double TransformR2PX(double value);
        double TransformR2PY(double value);
        double TransformR2PW(double value);
        double TransformR2PH(double value);

        void TransformR2PXY(double x, double y, out double outX, out double outY);
        void TransformR2PWH(double w, double h, out double outW, out double outH);

        dRect TransformR2P(dRect shape);
    }
}
