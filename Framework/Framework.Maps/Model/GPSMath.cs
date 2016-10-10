// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 10/Oct/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace GPS
{
    public static class GpsMath
    {
        // 
        // Just so we don't have to type the code whenerever we need the character
        //

        public static readonly string DEGREE_SYMBOL = ((char)176).ToString();

        // 
        // These values represent the forumulas shown in the associated comments.
        //

        public const int    AVG_EARTH_RADIUS_KM = 12742;                // 6371 * 2
        public const int    AVG_EARTH_RADIUS_MI = 7918;                 // 3919 * 2
        public const double RADS_PER_DEGREE     = 57.295779513082323;   // (180.0d / Math.PI)
        public const double DEGREES_PER_RAD     = 0.017453292519943295; // (Math.PI / 180.0d)

        public static double DegreeToRadian(double angle) 
        { 
            return DEGREES_PER_RAD * angle;
        }
 
        public static double RadianToDegree(double angle) 
        { 
            return RADS_PER_DEGREE * angle;
        }
    }
}
