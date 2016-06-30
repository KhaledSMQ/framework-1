// ============================================================================
// Project: Framework
// Name/Class: IProjectionV2R
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface for Virtual to Proportional projection.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjectionV2P : IXmlReady
    {
        //
        // TRANSFORM: Virtual --> Proportional
        //

        double TransformV2PX(double x);
        double TransformV2PY(double y);
        double TransformV2PW(double w);
        double TransformV2PH(double h);

        void TransformV2PXY(double x, double y, out double outX, out double outY);
        void TransformV2PWH(double w, double h, out double outW, out double outH);

        dRect TransformV2P(dRect inShape);
    }
}
