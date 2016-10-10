using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
	public abstract class LatLongBase
	{
		#region enumerators

		/// <summary>
		/// Compass point enumerator
		/// </summary>
		public enum CompassPoint { N,W,E,S }

		///// <summary>
		///// Coordinate type enumerator
		///// </summary>
		//public enum CoordType { Lat, Long }

		#endregion enumerators


		#region properties
		/// <summary>
		/// Get/set the precision to be applied to calculated values (mostly dealing withe the Value 
		/// property)
		/// </summary>
		public int          MathPrecision  { get; set; }

		/// <summary>
		/// Get/set the actual value of this coordintae part. This value is used to determine 
		/// degrees/minutes/seconds when they're needed.
		/// </summary>
		public double       Value          { get; set; }

		/// <summary>
		/// The compass point represented by this coordinate part
		/// </summary>
		public CompassPoint Direction      { get; set; }

		/// <summary>
		/// Gets the radians represented by the Value
		/// </summary>
		public double Radians 
		{ 
			get { return Math.Round(GPSMath.DegreeToRadian(this.Value), this.MathPrecision); } 
		}

		/// <summary>
		/// Gets the degrees rpresented by the Value.
		/// </summary>
		public double Degrees 
		{ 
			get { return Math.Round(GPSMath.RadianToDegree(this.Value), this.MathPrecision); } 
		}

		#endregion properties

		#region constructors

		/// <summary>
		/// Creates an instance of this object using the specified degrees, minutes, and seconds
		/// </summary>
		/// <param name="degs">The degrees (can be a negative number, representing a west or south 
		/// coordinate). The min/max value is determined by whether this is a longitude or latitude 
		/// value.</param>
		/// <param name="mins">The minutes. Value must be 0-60.</param>
		/// <param name="secs">TYhe seconds. Value must be 0d-60d.</param>
		/// <param name="mathPrecision">Precision used for math calculations.</param>
		public LatLongBase(int degs, int mins, double secs, int mathPrecision = 6)
		{
			this.SanityCheck(degs, mins, secs, mathPrecision);
			this.MathPrecision = mathPrecision;
			this.DMSToValue(degs, mins, secs);
			this.SetDirection();
		}

		/// <summary>
		/// Creates an instance of this object using the specified degrees and minutes
		/// </summary>
		/// <param name="degs">The degrees (can be a negative number, representing a west or south 
		/// coordinate). The min/max value is determined by whether this is a longitude or latitude 
		/// value.</param>
		/// <param name="mins">The minutes. Value must be 0d-60d.</param>
		/// <param name="mathPrecision">Precision used for math calculations.</param>
		public LatLongBase(int degs, double mins, int mathPrecision = 6)
		{
			this.SanityCheck(degs, mins, mathPrecision);
			this.MathPrecision = mathPrecision;
			int tempMins = (int)(Math.Floor(mins));
			double secs  = 60d * (mins - tempMins);
			this.DMSToValue(degs, tempMins, secs);
			this.SetDirection();
		}

		/// <summary>
		/// Creates and instance of this object with the specified value
		/// </summary>
		/// <param name="value">The value (can be a negative number, representing a west or south 
		/// coordinate). The min/max value is determined by whether this is a longitude or latitude 
		/// value.</param>
		/// <param name="mathPrecision">Precision used for math calculations.</param>
		public LatLongBase(double value, int mathPrecision = 6)
		{
			this.SanityCheck(value, mathPrecision);

			this.MathPrecision = mathPrecision;
			this.Value = value;
			this.SetDirection();
		}

		/// <summary>
		/// Convert the specified string to a coordinate component. 
		/// </summary>
		/// <param name="coord">The coordinate as a string. Can be in one of the following formats 
		/// (where X is the appropriate compass point and the minus is used to indicate W or S 
		/// compass poiints):
		///     - [X][-]dd mm ss.s 
		///     - [X][-]dd* mm' ss.s" 
		///     - [X][-]dd mm.m (degrees minutes.percentage of minute)
		///     - [X][-]dd.d (degrees)
		/// </param>
		/// <param name="mathPrecision">Precision used for math calculations.</param>
		public LatLongBase(string coord, int mathPrecision = 6)
		{
			// 1st sanity check - make sure the string isn't empty
			this.SanityCheck(coord, mathPrecision);

			this.MathPrecision = mathPrecision;

			// Convert compass points to their appropriate sign - for easier manipulation, we remove 
			// the compass points and if necessary, replace with a minus sign to indicate the 
			// appropriate direction.
			coord = coord.ToUpper();
			coord = this.AdjustCoordDirection(coord);

			// Get rid of the expected segment markers (degree, minute, and second symbols) and 
			// trim off any whitespace.
			coord = coord.Replace("\"", "").Replace("'", "").Replace(GPSMath.DEGREE_SYMBOL, "").Trim();

			// 2nd sanity check - Now that we've stripped all the unwanted stuff from the string, 
			// let's make sure we still have a string with content.
			this.SanityCheckString(coord);

			// split the string at space characters
			string[] parts = coord.Split(' ');
			bool     valid = false;
			int      degs  = 0;
			int      mins  = 0;
			double   secs  = 0d;

			// depending on how many "parts" there are in the string, we try to parse the value(s).
			switch (parts.Length)
			{
				case 1 :
					{
						// Assume that the part is a double value. that can merely be parsed and 
						// assigned to the Value property.
						double value;
						if (double.TryParse(coord, out value))
						{
							this.SanityCheck(value, mathPrecision);
							this.Value = value;
						}
						else
						{
							throw new ArgumentException("Could not parse coordinate value. Expected degreees (decimal).");
						}
					}
					break;
				case 2 :
					{
						// Assume that the parts are "degrees minutes". 
						double minsTemp = 0d;
						for (int i = 0; i < parts.Length; i++)
						{
							switch (i)
							{
								case 0 :
									{
										valid = (int.TryParse(parts[i], out degs));
									}
									break;
								case 1 :
									{
										valid = (double.TryParse(parts[i], out minsTemp));
									}
									break;
							}
						}
						if (!valid)
						{
							throw new ArgumentException("Could not parse coordinate value. Expected degrees (int), and minutes (double), i.e. 12 34.56.");
						}
						else
						{
							// if the values parsed as expected, we need to separate the minutes from the seconds.
							mins = (int)(Math.Floor(minsTemp));
							secs = Math.Round(60d * (minsTemp - mins), 3);
							this.SanityCheck(degs, mins, secs, 3);
						}
					}
					break;
				case 3 :
					{
						// Assume that the parts are "degrees minutes seconds". 
						for (int i = 0; i < parts.Length; i++)
						{
							switch (i)
							{
								case 0 :
									{
										valid = (int.TryParse(parts[i], out degs));
									}
									break;
								case 1 :
									{
										valid = (int.TryParse(parts[i], out mins));
									}
									break;
								case 2 :
									{
										valid = (double.TryParse(parts[i], out secs));
									}
									break;
							}
						}
						if (!valid)
						{
							throw new ArgumentException("Could not parse coordinate value. Expected degrees (int), and minutes (int), and seconds (double), i.e. 12 34 56.789.");
						}
						else
						{
							this.SanityCheck(degs, mins, secs, mathPrecision);
						}
					}
					break;
			}

			// If everything is valid and our we had more than one parameter, convert the parsed 
			// degrees, minutes, and seconds, and assign the result to the Value property, and 
			// finally, set the compass point.
			if (valid && parts.Length > 1)
			{
				this.DMSToValue(degs, mins, secs);
				this.SetDirection();
			}
		}

		#endregion constructors

		#region helper methods

		/// <summary>
		/// Returns the Value of this object as a GPS coordinate part.
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		/// <remarks>
		/// Valid format string values (anything else will generate an exception). If a null/empty 
		/// string is specified, the "DA" format will be used.
		///     - DA = "N0* 0' 0"", where N indicates the appropriate direction at the BEGINNING of the string
		///     - da = "-0* 0' 0"", where "-" is prepended if the coordinate part is either west or south
		///     - AD = "0* 0' 0"N", where N indicates the appropriate direction at the END of the string
		///     - DV = "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
		///     - dv = "-0.00000", where "-" is prepended if the coordinate part is either west or south
		///     - VD = "0.00000N", where N indicates the appropriate direction at the END of the string
		/// </remarks>
		public string ToString(string format)
		{
			if (string.IsNullOrEmpty(format))
			{
				format = "DA";
			}
			string result = string.Empty;
			switch (format)
			{
				case "DA" : // "N0* 0' 0"" where N indicates the appropriate direction at the BEGINNING of the string
				case "da" : // "-0* 0' 0"", where "-" is prepended if the coordinate part is either west or south
					{
						result = this.AppendDirection(this.FormatAsDMS(), format);
					}
					break;
				case "AD" : // "0* 0' 0"N", where N indicates the appropriate direction at the END of the string
					{
						result = this.AppendDirection(this.FormatAsDMS(), format);
					}
					break;

				case "DV" : // "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
				case "dv" : // "-0.00000", where "-" is prepended if the coordinate part is either west or south
					{
						result = this.AppendDirection(string.Format("{0:0.00000}",this.Value), format);
					}
					break;
				case "VD" : // "0.00000N", where N indicates the appropriate direction at the END of the string
					{
						result = this.AppendDirection(string.Format("{0:0.00000}",this.Value), format);
					}
					break;
				default :
					throw new ArgumentException("Invalid GPS coordinate string format");
			}
			return result;
		}

		/// <summary>
		/// Converts the current Value to degrees/minutes/seconds, and returns those calculated 
		/// values via the "out" properties.
		/// </summary>
		/// <param name="degs">The calculated degrees.</param>
		/// <param name="mins">The calculated minutes.</param>
		/// <param name="secs">The calculated seconds.</param>
		private void ValueToDMS(out int degs, out int mins, out double secs)
		{
			degs = (int)this.Value;
			secs = (Math.Abs(this.Value) * 3600) % 3600;
			mins = (int)(Math.Abs(secs / 60d));
			secs = Math.Round(secs % 60d, 3);
		}

		/// <summary>
		/// Converts the specified degrees/minutes/seconds to a single value, and sets the Value 
		/// property.
		/// </summary>
		/// <param name="degs">The degrees</param>
		/// <param name="mins">The minutes</param>
		/// <param name="secs">The seconds</param>
		private void DMSToValue(int degs, int mins, double secs)
		{
			double adjuster  = (degs < 0) ? -1d : 1d;
			this.Value = Math.Round((Math.Abs(degs) + (mins/60d) + (secs/3600d)) * adjuster, this.MathPrecision);
		}

		/// <summary>
		/// Formats a string using the degrees, minutes and seconds of the coordinate.
		/// </summary>
		/// <returns>A string formatted as "0* 0' 0"".</returns>
		private string FormatAsDMS()
		{
			string result = string.Empty;
			int degs;
			int mins;
			double secs;
			this.ValueToDMS(out degs, out mins, out secs);
			result = string.Format("{0}{1} {2}' {3}\"", Math.Abs(degs), GPSMath.DEGREE_SYMBOL, mins, secs);
			return result;
		}

		/// <summary>
		/// Appends either the compass point, or a minus symbol (if appropriate, and indicated by the specified format).
		/// </summary>
		/// <param name="coord">The coordinate string</param>
		/// <param name="format">The format indicator</param>
		/// <returns>The adjusted coordinate string</returns>
		private string AppendDirection(string coord, string format)
		{
			string result = string.Empty;
			switch (format)
			{
				case "da" :
				case "dv" :
					result = string.Concat("-",coord);
					break;
				case "DA" :
				case "DV" :
					result = string.Concat(this.Direction.ToString(), coord.Replace("-", ""));
					break;
				case "AD" :
				case "VD" :
					result = string.Concat(coord, this.Direction.ToString());
					break;
			}
			return result;
		}

		#endregion helper methods

		#region abstract  methods (lat or long specific)

		/// <summary>
		/// Sets the directionType for this object based on whether this object is a latitude or a 
		/// longitude, and the Value of the coordinate.
		/// </summary>
		protected abstract void   SetDirection();
		/// <summary>
		/// Adjusts the direction based on whether this is a latitude or longitude
		/// </summary>
		/// <param name="coord">The string coordinate</param>
		/// <returns>The adjusted coordinate string</returns>
		protected abstract string AdjustCoordDirection(string coord);
		/// <summary>
		/// Gets the maximum value of the degrees based on whether or not this is a latitude or 
		/// longitude.
		/// </summary>
		/// <returns>The maximum allowed degrees.</returns>
		protected abstract int    GetMaxDegrees();

		#endregion abstract  methods (lat or long specific)

		#region sanity check methods (one for each constructor)

		private void SanityCheck(int degs, int mins, double secs, int mathPrecision)
		{
			int maxDegrees = this.GetMaxDegrees();
			int minDegrees = maxDegrees * -1;

			if (degs < minDegrees || degs > maxDegrees)
			{
				throw new ArgumentException(string.Format("Degrees MUST be {0} - {1}", minDegrees, maxDegrees));
			}
			if (mins < 0 || mins > 60)
			{
				throw new ArgumentException("Minutes MUST be 0 - 60");
			}
			if (secs < 0 || secs > 60)
			{
				throw new ArgumentException("Seconds MUST be 0 - 60");
			}
			this.SanityCheckPrecision(mathPrecision);
		}

		private void SanityCheck(int degs, double mins, int mathPrecision)
		{
			int maxDegrees = this.GetMaxDegrees();
			int minDegrees = maxDegrees * -1;

			if (degs < minDegrees || degs > maxDegrees)
			{
				throw new ArgumentException(string.Format("Degrees MUST be {0} - {1}", minDegrees, maxDegrees));
			}
			if (mins < 0d || mins > 60d)
			{
				throw new ArgumentException("Minutes MUST be 0.0 - 60.0");
			}
			this.SanityCheckPrecision(mathPrecision);
		}

		private void SanityCheck(double value, int mathPrecision)
		{
			double maxValue = (double)this.GetMaxDegrees();
			double minValue = maxValue * -1;

			if (value < minValue || value > maxValue)
			{
				throw new ArgumentException(string.Format("Degrees MUST be {0} - {1}", minValue, maxValue));
			}
			this.SanityCheckPrecision(mathPrecision);
		}

		private void SanityCheck(string coord, int mathPrecision)
		{
			this.SanityCheckString(coord);
			this.SanityCheckPrecision(mathPrecision);
		}

		private void SanityCheckString(string coord)
		{
			if (string.IsNullOrEmpty(coord))
			{
				throw new ArgumentException("The coordinate string cannot be null/empty.");
			}
		}

		private void SanityCheckPrecision(int mathPrecision)
		{
			// You can have a maximum of 17 digits to the right of the decimal point in a double 
			// value, but when you do ANY math on the value, the 17th digit may or may not reflect 
			// the actual value (research math and equality on doubles for more info). For this 
			// reason, I recommend using a precision value of nothing higher than 16. The default 
			// value is 6.
			if (mathPrecision < 0 || mathPrecision > 17)
			{
				throw new ArgumentException("Math precision MUST be 0 - 17");
			}
		}

		#endregion sanity check methods (one for each constructor)

	}

}
