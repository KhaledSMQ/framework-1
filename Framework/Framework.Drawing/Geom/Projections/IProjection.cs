// ============================================================================
// Project: Framework
// Name/Class: IProjection
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Interface that includes all sub projections.
// ============================================================================

using System;
using Framework.Core.Patterns;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Projections
{
    public interface IProjection :
        IXmlReady,
        ICloneable,
        IProjectionP2R,
        IProjectionP2V,
        IProjectionR2P,
        IProjectionR2V,
        IProjectionR2A,
        IProjectionV2P,
        IProjectionV2R,
        IProjectionV2A
    {
        //
        //  VIRTUAL SURFACE
        //  Properties & Methods
        //

        #region Virtual Surface Properties & Methods

        double VirtualSurfaceX { get; }
        double VirtualSurfaceY { get; }
        double VirtualSurfaceWidth { get; }
        double VirtualSurfaceHeight { get; }

        void ChangeVirtualSurfaceXY(double newX, double newY);
        void ChangeVirtualSurfaceWH(double newW, double newH);
        void ChangeVirtualSurface(dRect newShape);
        void ChangeVirtualSurface(double newX, double newY, double newW, double newH);

        #endregion

        //
        //  REAL SURFACE
        //  Properties & Methods
        //

        #region Real Surface Properties & Methods

        double RealSurfaceX { get; }
        double RealSurfaceY { get; }
        double RealSurfaceWidth { get; }
        double RealSurfaceHeight { get; }

        void ChangeRealSurfaceXY(double newX, double newY);
        void ChangeRealSurfaceWH(double newW, double newH);
        void ChangeRealSurface(dRect shape);
        void ChangeRealSurface(double newX, double newY, double newWidth, double newHeight);

        #endregion

        //
        //  TRANSFORMATIONS
        //  Properties & Methods
        //

        #region Transformations

        double ScaleVirtual2RealX { get; }
        double ScaleVirtual2RealY { get; }

        double ScaleReal2VirtualX { get; }
        double ScaleReal2VirtualY { get; }

        #endregion
    }
}
