// ============================================================================
// Project: Framework
// Name/Class: AProjection
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Projection concrete class.
// ============================================================================

namespace Framework.Drawing.Geom.Projections
{
    public class Projection : AProjection
    {
        //
        // CONSTRUCTORS
        //

        public Projection() : base() { }

        //
        // STANDARD
        //

        public override object Clone()
        {
            Projection clonned = new Projection();
            clonned.ChangeVirtualSurfaceXY(this.VirtualSurfaceX, this.VirtualSurfaceY);
            clonned.ChangeVirtualSurfaceWH(this.VirtualSurfaceWidth, this.VirtualSurfaceHeight);
            clonned.ChangeRealSurfaceXY(this.RealSurfaceX, this.RealSurfaceY);
            clonned.ChangeRealSurfaceWH(this.RealSurfaceWidth, this.RealSurfaceHeight);
            clonned.ComputeScales();
            return clonned;
        }
    }
}
