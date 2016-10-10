// ============================================================================
// Project: Framework
// Name/Class: Latitude
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 10/Oct/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace GPS
{
    public class Latitude : LatLongBase
    {
        //
        // CONSTRUCTORS
        //

        public Latitude(int degs, int mins, double secs) : base(degs, mins, secs) { }

        public Latitude(int degs, double mins) : base(degs, mins) { }

        public Latitude(double coord) : base(coord) { }

        public Latitude(string coord) : base(coord) { }

        //
        // Sets the direction for this object based on whether this object 
        // is a latitude or a longitude, and the Value of the coordinate.
        //

        protected override void SetDirection()
        {
            Direction = (this.Value < 0d) ? CompassPoint.S : CompassPoint.N;
        }

        //
        // Adjusts the direction based on whether this is a latitude or longitude
        // @param coord The string coordinate.
        // @returns The adjusted coordinate string.
        //

        protected override string AdjustCoordDirection(string coord)
        {
            if (coord.StartsWith("S") || coord.EndsWith("S"))
            {
                coord = string.Concat("-", coord.Replace("S", ""));
            }
            else
            {
                coord = coord.Replace("N", "");
            }
            return coord;
        }

        //
        // Gets the maximum value of the degrees based on whether
        // or not this is a latitude or longitude.
        // @returns The maximum allowed degrees.
        //

        protected override int GetMaxDegrees()
        {
            return 90;
        }
    }
}
