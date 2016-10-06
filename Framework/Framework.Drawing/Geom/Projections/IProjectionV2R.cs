// ============================================================================
// Project: Framework
// Name/Class: IProjectionV2R
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Virtual to Real projection.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionV2R : IXmlReady
    {
        double TransformV2RX(double x);
        double TransformV2RY(double y);
        double TransformV2RW(double x);
        double TransformV2RH(double y);

        void TransformV2RXY(double x, double y, out double outX, out double outY);
        void TransformV2RWH(double w, double h, out double outW, out double outH);

        dRect TransformV2R(dRect inShape);
    }
}
