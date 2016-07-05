// ============================================================================
// Project: Framework
// Name/Class: IProjectionP2R
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Proportional to Real projection.
// ============================================================================

using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionP2R
    {
        double TransformP2RX(double value);
        double TransformP2RY(double value);
        double TransformP2RW(double value);
        double TransformP2RH(double value);

        void TransformP2RXY(double x, double y, out double outX, out double outY);
        void TransformP2RWH(double w, double h, out double outW, out double outH);

        dRect TransformP2R(dRect shape);
    }
}
