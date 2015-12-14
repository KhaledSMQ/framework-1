// ============================================================================
// Project: Framework
// Name/Class: IProjectionR2P
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Cybermap Lta.
// Description: Interface for Real to Proportional projection.
// ============================================================================

using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionR2A
    {
        double TransformR2AX(double value);
        double TransformR2AY(double value);

        double TransformR2AW(double value);
        double TransformR2AH(double value);

        void TransformR2AXY(double x, double y, out double outX, out double outY);
        void TransformR2AWH(double w, double h, out double outW, out double outH);

        dRect TransformR2A(dRect shape);
    }
}
