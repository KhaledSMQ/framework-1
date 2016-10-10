using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
	/// <summary>
	/// Represents a latitude position
	/// </summary>
	public class Latitude : LatLongBase
	{
		#region constructors

		public Latitude(int degs, int mins, double secs):base(degs, mins, secs)
		{
		}

		public Latitude(int degs, double mins):base(degs, mins)
		{
		}

		public Latitude(double coord):base(coord)
		{
		}

		public Latitude(string coord):base(coord)
		{
		}

		#endregion constructors

		#region overridden abstract methods

		/// <summary>
		/// Sets the directionType for this object based on whether this object is a latitude or a 
		/// longitude, and the Value of the coordinate.
		/// </summary>
		protected override void SetDirection()
		{
			this.Direction = (this.Value < 0d) ? CompassPoint.S : CompassPoint.N;
		}

		/// <summary>
		/// Adjusts the direction based on whether this is a latitude or longitude
		/// </summary>
		/// <param name="coord">The string coordinate</param>
		/// <returns>The adjusted coordinate string</returns>
		protected override string AdjustCoordDirection(string coord)
		{
			if (coord.StartsWith("S") || coord.EndsWith("S"))
			{
				coord = string.Concat("-",coord.Replace("S", ""));
			}
			else
			{
				coord = coord.Replace("N", "");
			}
			return coord;
		}

		/// <summary>
		/// Gets the maximum value of the degrees based on whether or not this is a latitude or 
		/// longitude.
		/// </summary>
		/// <returns>The maximum allowed degrees.</returns>
		protected override int GetMaxDegrees()
		{
			return 90;
		}

		#endregion overridden abstract methods
	}

	/// <summary>
	/// Represents a longitude position.
	/// </summary>
	public class Longitude : LatLongBase
	{
		#region constructors

		public Longitude(int degs, int mins, double secs):base(degs, mins, secs)
		{
		}

		public Longitude(int degs, double mins):base(degs, mins)
		{
		}

		public Longitude(double coord):base (coord)
		{
		}

		public Longitude(string coord):base(coord)
		{
		}

		#endregion constructors

		#region overridden abstract methods

		/// <summary>
		/// Sets the directionType for this object based on whether this object is a latitude or a 
		/// longitude, and the Value of the coordinate.
		/// </summary>
		protected override void SetDirection()
		{
			this.Direction = (this.Value < 0d) ? CompassPoint.W : CompassPoint.E;
		}

		/// <summary>
		/// Adjusts the direction based on whether this is a latitude or longitude
		/// </summary>
		/// <param name="coord">The string coordinate</param>
		/// <returns>The adjusted coordinate string</returns>
		protected override string AdjustCoordDirection(string coord)
		{
			if (coord.StartsWith("W") || coord.EndsWith("W"))
			{
				coord = string.Concat("-",coord.Replace("W", ""));
			}
			else
			{
				coord = coord.Replace("E", "");
			}
			return coord;
		}

		/// <summary>
		/// Gets the maximum value of the degrees based on whether or not this is a latitude or 
		/// longitude.
		/// </summary>
		/// <returns>The maximum allowed degrees.</returns>
		protected override int GetMaxDegrees()
		{
			return 180;
		}

		#endregion overridden abstract methods
	}

}
