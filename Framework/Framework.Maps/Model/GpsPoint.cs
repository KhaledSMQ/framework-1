// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 10/Oct/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace GPS
{
    public class GpsPoint
    {
        //
        // ENUMERATION: Type of distance metric.
        //

        public enum DistanceMetric { MILES, KILOMETERS }

        //
        // Get/set the latitude for this position
        //

        public Latitude Latitude { get; set; }

        //
        // Get/set the longitude for this position
        //

        public Longitude Longitude { get; set; }

        //
        // CONSTRUCTORS
        //

        public GpsPoint(Latitude latitude, Longitude longitude)
        {
            SanityCheck(latitude, longitude);
            Latitude = latitude;
            Longitude = longitude;
        }

        public GpsPoint(double latitude, double longitude)
        {
            SanityCheck(latitude, longitude);
            Latitude = new Latitude(latitude);
            Longitude = new Longitude(longitude);
        }

        public GpsPoint(string latlong) : this(latlong, ',') { }

        public GpsPoint(string latlong, char delimiter)
        {
            SanityCheck(latlong, delimiter);

            string[] parts = latlong.Split(delimiter);
            if (parts.Length != 2)
            {
                throw new ArgumentException("Expecting two fields - a latitude and logitude separated by the specified delimiter.");
            }

            //
            // The LatLongBase class takes care of sanity checks for the specified part elements, 
            // so all we need to do is try to creat instances of them.
            //

            Latitude = new Latitude(parts[0]);
            Longitude = new Longitude(parts[1]);
        }

        //
        // Calculates the distance from this GPS position to the specified position.
        // @param thatPo The position to which we are calculating the bearing.
        // @param distanceType The type of measurement (miles or kilometers)
        // @param validat >Determines if the math is sound by calculating the distance in 
        // both directions. Default value is false, and the value is only used when the application 
        // is compiled in debug mode.</param>
        // @returns The distance between this position and the specified position, of the specified 
        // distance type (miles or kilometers)</returns>
        // @remarks Validate is only active if the solution is compiled in debug mode, and consists 
        // of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
        // InvalidOperationException is thrown.
        //

        public double DistanceFrom(GpsPoint thatPos)
        {
            return DistanceFrom(thatPos, DistanceMetric.MILES, false);
        }

        public double DistanceFrom(GpsPoint thatPos, DistanceMetric distanceType)
        {
            return DistanceFrom(thatPos, distanceType, false);
        }

        public double DistanceFrom(GpsPoint thatPos, DistanceMetric distanceType, bool validate)
        {
            double thisX;
            double thisY;
            double thisZ;
            GetXYZForDistance(out thisX, out thisY, out thisZ);

            double thatX;
            double thatY;
            double thatZ;
            GetXYZForDistance(out thatX, out thatY, out thatZ);

            double diffX = thisX - thatX;
            double diffY = thisY - thatY;
            double diffZ = thisZ - thatZ;
            double arc = Math.Sqrt((diffX * diffX) + (diffY * diffY) + (diffZ * diffZ));

            double distance = Math.Round(((distanceType == DistanceMetric.MILES) 
                              ? GpsMath.AVG_EARTH_RADIUS_MI 
                              : GpsMath.AVG_EARTH_RADIUS_KM) * Math.Asin(arc), 1);

#if DEBUG
            if (validate)
            {
                double reverseDistance = thatPos.DistanceFrom(this, distanceType, false);
                if (distance != reverseDistance)
                {
                    throw new InvalidOperationException("Distance value did not validate.");
                }
            }
#endif

            return distance;
        }

        //
        // Creates a Rhumb bearing from this GPS position to the specified position.
        // @param thatPos The position to which we are calculating the bearing.
        // @param validate Determines if the math is sound by calculating the bearing in
        // both directions and verifying that the difference is 180 degrees. Default value is 
        // false, and the value is only used when the application is compiled in debug mode.</param>
        // @returns The bearing value in degrees, rounded to the nearest whole number.
        // @remarks Validate is only active if the solution is compiled in debug mode, and consists 
        // of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
        // InvalidOperationException is thrown.
        //

        public double BearingTo(GpsPoint thatPos)
        {
            return BearingTo(thatPos, false);
        }

        public double BearingTo(GpsPoint thatPos, bool validate)
        {
            double heading = 0d;
            double lat1 = GpsMath.DegreeToRadian(this.Latitude.Value);
            double lat2 = GpsMath.DegreeToRadian(thatPos.Latitude.Value);
            double diffLong = GpsMath.DegreeToRadian((double)((decimal)thatPos.Longitude.Value - (decimal)this.Longitude.Value));
            double dPhi = Math.Log(Math.Tan(lat2 * 0.5 + Math.PI / 4) / Math.Tan(lat1 * 0.5 + Math.PI / 4));
            if (Math.Abs(diffLong) > Math.PI)
            {
                diffLong = (diffLong > 0) ? -(2 * Math.PI - diffLong) : (2 * Math.PI + diffLong);
            }
            double bearing = Math.Atan2(diffLong, dPhi);

            heading = Math.Round((GpsMath.RadianToDegree(bearing) + 360) % 360, 0);
#if DEBUG
            if (validate)
            {
                double reverseHeading = thatPos.BearingTo(this, false);
                if (Math.Round(Math.Abs(heading - reverseHeading), 0) != 180d)
                {
                    throw new InvalidOperationException("Heading value did not validate");
                }
            }
#endif
            return heading;
        }

        //
        // Creates a Rhumb bearing from the specified position to this GPS position.
        // @param thatPos The position from which we are calculating the bearing.
        // @param validate Determines if the math is sound by calculating the bearing in 
        // both directions and verifying that the difference is 180 degrees. Default value is 
        // false, and the value is only used when the application is compiled in debug mode.
        // @returns The bearing value in degrees, rounded to the nearest whole number.
        // @remarks Validate is only active if the solution is compiled in debug mode, and consists 
        // of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
        // InvalidOperationException is thrown.
        //

        public double BearingFrom(GpsPoint thatPos)
        {
            return BearingFrom(thatPos, false);
        }

        public double BearingFrom(GpsPoint thatPos, bool validate)
        {
            return thatPos.BearingTo(this, validate);
        }

        //
        // Formats the coordinate parts using the specified format string.
        // @param name="format">The format string</param>
        // @returns The combined coordinate parts.
        // @remarks
        // Valid format string values (anything else will generate an exception). If a null/empty 
        // string is specified, the "DA" format will be used.
        //     - DA = "N0* 0' 0", where N indicates the appropriate direction at the BEGINNING of the string
        //     - da = "-0* 0' 0", where - is prepended if the coordinate part is either west or south
        //     - AD = "0* 0' 0"N, where N indicates the appropriate direction at the END of the string
        //     - DV = "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
        //     - dv = "-0.00000", where - is prepended if the coordinate part is either west or south
        //     - VD = "0.00000N", where N indicates the appropriate direction at the END of the string
        //

        public string ToString(string format)
        {
            //
            // Format string validation is performed in the Latitude and Longitude objects. An 
            // exception will be thrown if the specified format is not valid.
            //

            return string.Concat(Latitude.ToString(format), ",", Longitude.ToString(format));
        }

        //
        // Math function for distance calculation.
        //

        private void GetXYZForDistance(out double x, out double y, out double z)
        {
            x = 0.5 * Math.Cos(this.Latitude.Radians) * Math.Sin(this.Longitude.Radians);
            y = 0.5 * Math.Cos(this.Latitude.Radians) * Math.Cos(this.Longitude.Radians);
            z = 0.5 * Math.Sin(this.Latitude.Radians);
        }

        private void SanityCheck(Latitude latitude, Longitude longitude)
        {
            if (latitude == null)
            {
                throw new ArgumentNullException("latitude");
            }
            if (longitude == null)
            {
                throw new ArgumentNullException("longitude");
            }
        }

        private void SanityCheck(double latitude, double longitude)
        {
            double maxLat = 90d;
            double maxLong = 180d;
            double minLat = maxLat * -1;
            double minLong = maxLong * -1;

            if (latitude < minLat || latitude > maxLat)
            {
                throw new ArgumentException(string.Format("Latitude MUST be {0} - {1}", minLat, maxLat));
            }
            if (longitude < minLong || longitude > maxLong)
            {
                throw new ArgumentException(string.Format("Longitude MUST be {0} - {1}", minLong, maxLong));
            }
        }

        //
        // Validates the constructor parameter and delimiter character.
        // @param latlong The lat,long string.
        // @param delimiter The delimiter character
        //

        private void SanityCheck(string latlong, char delimiter)
        {
            // 
            // Make sure we have a string
            //

            if (string.IsNullOrEmpty(latlong))
            {
                throw new ArgumentNullException("latlong");
            }

            // 
            // Set the easy ones (numbers, space and period)
            //

            string invalidChars = "0123456789 .'";

            for (int i = 0; i < 256; i++)
            {                
                if (i < 32 || i > 127)
                {
                    //
                    // And then add "non-printables" (and special characters
                    //

                    invalidChars = string.Concat(invalidChars, (char)i);
                }                
                else if ((i > 64 && i < 91) || (i > 60 && i < 123))
                {
                    //
                    // And the entire alphabet
                    //

                    invalidChars = string.Concat(invalidChars, (char)i);
                }
            }
            if (invalidChars.Contains(delimiter))
            {
                throw new ArgumentException("The specified delimiter is not a recognized delimiter character");
            }
        }

        //
        // A static method to calcculate the distance between two or more points.
        // @param points The collection of points to calculate with (there must be at least two points.
        // @param distanceType Miles or kilometers
        // @returns Zero if there are fewer that two points, or the total disance between all points.
        //

        public static double TotalDistanceBetweenManyPoints(IEnumerable<GpsPoint> points, GpsPoint.DistanceMetric distanceType = GpsPoint.DistanceMetric.MILES)
        {
            double result = 0d;
            if (points.Count() > 1)
            {
                GpsPoint pt1 = null;
                GpsPoint pt2 = null;
                for (int i = 1; i < points.Count(); i++)
                {
                    pt1 = points.ElementAt(i - 1);
                    pt2 = points.ElementAt(i);
                    result += pt1.DistanceFrom(pt2, distanceType);
                }
            }
            return result;
        }
    }
}
