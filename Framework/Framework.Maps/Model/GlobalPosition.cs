using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
	/// <summary>
	/// Represents a global position, consisting of a latitude and logitude.
	/// </summary>
	public class GlobalPosition
	{
		public enum DistanceType { Miles, Kilometers }

		/// <summary>
		/// Get/set the latitude for this position
		/// </summary>
		public Latitude     Latitude        { get; set; }
		/// <summary>
		/// Get/set the longitude for this position
		/// </summary>
		public Longitude    Longitude       { get; set; }

		#region constructors

		/// <summary>
		/// Create an instance of this object, using a Latitude object parameter, and a Longitude object parameter.
		/// </summary>
		/// <param name="latitude">An instantiated Latitude object.</param>
		/// <param name="longitude">An instantiated Longitude object.</param>
		public GlobalPosition(Latitude latitude, Longitude longitude)
		{
			this.SanityCheck(latitude, longitude);

			this.Latitude = latitude;
			this.Longitude = longitude;
		}

		/// <summary>
		/// Create an instance of this object, using a latitude value parameter, and a longitude value parameter.
		/// </summary>
		/// <param name="latitude">A valud indicating the latitude of the coordinate.</param>
		/// <param name="longitude">A value indicating the longitude of the coordinate.</param>
		public GlobalPosition(double latitude, double longitude)
		{
			this.SanityCheck(latitude, longitude);

			this.Latitude = new Latitude(latitude);
			this.Longitude = new Longitude(longitude);
		}

		/// <summary>
		/// Create an instance of this object with a string that represents some form of latitude 
		/// AND longitude, using the specified delimiter to parse the string.
		/// </summary>
		/// <param name="latlong">The lat/long string. Each part must be a valid coordinate part. 
		/// See the LatLongBase class for more information.</param>
		/// <param name="delimiter">The delimiter used to separate the coordinate parts. Default 
		/// value is a comma.</param>
		public GlobalPosition(string latlong, char delimiter=',')
		{
			this.SanityCheck(latlong, delimiter);

			string[] parts = latlong.Split(delimiter);
			if (parts.Length != 2)
			{
				throw new ArgumentException("Expecting two fields - a latitude and logitude separated by the specified delimiter.");
			}

			// The LatLongBase class takes care of sanity checks for the specified part elements, 
			// so all we need to do is try to creat instances of them.
			this.Latitude  = new Latitude(parts[0]);
			this.Longitude = new Longitude(parts[1]);
		}

		#endregion constructors

		/// <summary>
		/// Calculates the distance from this GPS position to the specified position.
		/// </summary>
		/// <param name="thatPos">The position to which we are calculating the bearing.</param>
		/// <param name="distanceType">The type of measurement (miles or kilometers)</param>
		/// <param name="validate">Determines if the math is sound by calculating the distance in 
		/// both directions. Default value is false, and the value is only used when the application 
		/// is compiled in debug mode.</param>
		/// <returns>The distance between this position and the specified position, of the specified 
		/// distance type (miles or kilometers)</returns>
		/// <remarks>Validate is only active if the solution is compiled in debug mode, and consists 
		/// of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
		/// InvalidOperationException is thrown.</remarks>
		public double DistanceFrom(GlobalPosition thatPos, GlobalPosition.DistanceType distanceType = GlobalPosition.DistanceType.Miles, bool validate=false)
		{
			double thisX;
			double thisY;
			double thisZ;
			this.GetXYZForDistance(out thisX, out thisY, out thisZ);

			double thatX;
			double thatY;
			double thatZ;
			thatPos.GetXYZForDistance(out thatX, out thatY, out thatZ);

			double diffX    = thisX - thatX;
			double diffY    = thisY - thatY;
			double diffZ    = thisZ - thatZ;
			double arc      = Math.Sqrt((diffX * diffX) + (diffY * diffY) + (diffZ * diffZ));

			double distance = Math.Round(((distanceType == DistanceType.Miles) ? GPSMath.AVG_EARTH_RADIUS_MI:GPSMath.AVG_EARTH_RADIUS_KM) * Math.Asin(arc), 1);

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

		/// <summary>
		/// Creates a Rhumb bearing from this GPS position to the specified position.
		/// </summary>
		/// <param name="thatPos">The position to which we are calculating the bearing.</param>
		/// <param name="validate">Determines if the math is sound by calculating the bearing in 
		/// both directions and verifying that the difference is 180 degrees. Default value is 
		/// false, and the value is only used when the application is compiled in debug mode.</param>
		/// <returns>The bearing value in degrees, rounded to the nearest whole number.</returns>
		/// <remarks>Validate is only active if the solution is compiled in debug mode, and consists 
		/// of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
		/// InvalidOperationException is thrown.</remarks>
		public double BearingTo(GlobalPosition thatPos, bool validate=false)
		{
			double heading  = 0d;
			double lat1     = GPSMath.DegreeToRadian(this.Latitude.Value);
			double lat2     = GPSMath.DegreeToRadian(thatPos.Latitude.Value);
			double diffLong = GPSMath.DegreeToRadian((double)((decimal)thatPos.Longitude.Value - (decimal)this.Longitude.Value));
			double dPhi     = Math.Log(Math.Tan(lat2 * 0.5 + Math.PI / 4) / Math.Tan(lat1 * 0.5 + Math.PI / 4));
			if (Math.Abs(diffLong) > Math.PI) 
			{
				diffLong = (diffLong > 0) ? -(2 * Math.PI - diffLong) : (2 * Math.PI + diffLong);
			}
			double bearing = Math.Atan2(diffLong, dPhi);
 
			heading = Math.Round((GPSMath.RadianToDegree(bearing) + 360) % 360, 0);
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

		/// <summary>
		/// Creates a Rhumb bearing from the specified position to this GPS position.
		/// </summary>
		/// <param name="thatPos">The position from which we are calculating the bearing.</param>
		/// <param name="validate">Determines if the math is sound by calculating the bearing in 
		/// both directions and verifying that the difference is 180 degrees. Default value is 
		/// false, and the value is only used when the application is compiled in debug mode.</param>
		/// <returns>The bearing value in degrees, rounded to the nearest whole number.</returns>
		/// <remarks>Validate is only active if the solution is compiled in debug mode, and consists 
		/// of ensuring that the recipricol bearing varies by 180 degrees. If it does not, an 
		/// InvalidOperationException is thrown.</remarks>
		public double BearingFrom(GlobalPosition thatPos, bool validate=false)
		{
			return thatPos.BearingTo(this, validate);
		}

		/// <summary>
		/// Formats the coordinate parts using the specified format string.
		/// </summary>
		/// <param name="format">The format string</param>
		/// <returns>The combined coordinate parts.</returns>
		/// <remarks>
		/// Valid format string values (anything else will generate an exception). If a null/empty 
		/// string is specified, the "DA" format will be used.
		///     - DA = "N0* 0' 0", where N indicates the appropriate direction at the BEGINNING of the string
		///     - da = "-0* 0' 0", where - is prepended if the coordinate part is either west or south
		///     - AD = "0* 0' 0"N, where N indicates the appropriate direction at the END of the string
		///     - DV = "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
		///     - dv = "-0.00000", where - is prepended if the coordinate part is either west or south
		///     - VD = "0.00000N", where N indicates the appropriate direction at the END of the string
		/// </remarks>
		public string ToString(string format)
		{
			// Format string validation is performed in the Latitude and Longitude objects. An 
			// exception will be thrown if the specified format is not valid.
			return string.Concat(this.Latitude.ToString(format),",",this.Longitude.ToString(format));
		}

		/// <summary>
		/// Math function for distance calculation.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		private void GetXYZForDistance(out double x, out double y, out double z)
		{
			x = 0.5 * Math.Cos(this.Latitude.Radians) * Math.Sin(this.Longitude.Radians);
			y = 0.5 * Math.Cos(this.Latitude.Radians) * Math.Cos(this.Longitude.Radians);
			z = 0.5 * Math.Sin(this.Latitude.Radians);
		}

		#region constructor sanity checks

		private void SanityCheck(Latitude latitude, Longitude longitude)
		{
			if (latitude == null)
			{
				throw new ArgumentNullException ("latitude");
			}
			if (longitude == null)
			{
				throw new ArgumentNullException ("longitude");
			}
		}

		private void SanityCheck(double latitude, double longitude)
		{
			double maxLat  = 90d;
			double maxLong = 180d;
			double minLat  = maxLat * -1;
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

		/// <summary>
		/// Validates the constructor parameter and delimiter character.
		/// </summary>
		/// <param name="latlong">The lat,long string</param>
		/// <param name="delimiter">The delimiter character</param>
		private void SanityCheck(string latlong, char delimiter)
		{
			// make sure we have a string
			if (string.IsNullOrEmpty(latlong))
			{
				throw new ArgumentNullException("latlong");
			}

			// set the easy ones (numbers, space and period)
			string invalidChars = "0123456789 .'";
			
			for (int i = 0; i<256; i++)
			{
				// and then add "non-printables" (and special characters
				if (i < 32 || i > 127)
				{
					invalidChars = string.Concat(invalidChars, (char)i);
				}
				// and the entire alphabet
				else if ((i > 64 && i < 91) || (i > 60 && i < 123))
				{
					invalidChars = string.Concat(invalidChars, (char)i);
				}
			}
			if (invalidChars.Contains(delimiter))
			{
				throw new ArgumentException("The specified delimiter is not a recognized delimiter character");
			}
		}

		#endregion constructor sanity checks

		/// <summary>
		/// A static method to calcculate the distance between two or more points.
		/// </summary>
		/// <param name="points">The collection of points to calculate with (there must be at least two points</param>
		/// <param name="distanceType">Miles or kilometers</param>
		/// <returns>Zero if there are fewer that two points, or the total disance between all points.</returns>
		public static double TotalDistanceBetweenManyPoints(IEnumerable<GlobalPosition> points, GlobalPosition.DistanceType distanceType = GlobalPosition.DistanceType.Miles)
		{
			double result = 0d;
			if (points.Count() > 1)
			{
				GlobalPosition pt1 = null;
				GlobalPosition pt2 = null;
				for (int i = 1; i < points.Count(); i++)
				{
					pt1 = points.ElementAt(i-1);
					pt2 = points.ElementAt(i);
					result += pt1.DistanceFrom(pt2, distanceType);
				}
			}
			return result;
		}
	}
}
