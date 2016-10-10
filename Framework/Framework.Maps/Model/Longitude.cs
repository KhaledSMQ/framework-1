// ============================================================================
// Project: Framework
// Name/Class: Longitude
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 10/Oct/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace GPS
{
    public class Longitude : LatLongBase
    {
        //
        // CONSTRUCTORS
        //

        public Longitude(int degs, int mins, double secs) : base(degs, mins, secs) { }

        public Longitude(int degs, double mins) : base(degs, mins) { }

        public Longitude(double coord) : base(coord) { }

        public Longitude(string coord) : base(coord) { }

        //
        // Sets the direction for this object based on whether this object
        // is a latitude or a longitude, and the Value of the coordinate.
        //

        protected override void SetDirection()
        {
            this.Direction = (this.Value < 0d) ? CompassPoint.W : CompassPoint.E;
        }

        //
        // Adjusts the direction based on whether this is a latitude or longitude
        // @param coord The string coordinate.
        // @return The adjusted coordinate string
        //

        protected override string AdjustCoordDirection(string coord)
        {
            if (coord.StartsWith("W") || coord.EndsWith("W"))
            {
                coord = string.Concat("-", coord.Replace("W", ""));
            }
            else
            {
                coord = coord.Replace("E", "");
            }

            return coord;
        }

        //
        // Gets the maximum value of the degrees based on whether or not 
        // this is a latitude or longitude.
        // @return The maximum allowed degrees.
        //

        protected override int GetMaxDegrees()
        {
            return 180;
        }
    }
}
