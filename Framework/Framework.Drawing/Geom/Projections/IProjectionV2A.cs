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
    public interface IProjectionV2A
    {
        double TransformV2AX(double value);
        double TransformV2AY(double value);
        double TransformV2AW(double value);
        double TransformV2AH(double value);

        void TransformV2AXY(double x, double y, out double outX, out double outY);
        void TransformV2AWH(double w, double h, out double outW, out double outH);

        dRect TransformV2A(dRect shape);
    }
}
