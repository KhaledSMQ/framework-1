// ============================================================================
// Project: Framework
// Name/Class: LatLongBase
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 10/Oct/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System;
using System.Globalization;

namespace GPS
{
    public abstract class LatLongBase
    {
        //
        // DEFAULTS
        //

        public static int DEFAULT_MATH_PRECISION = 6;

        //
        // ENUMERATOR: Compass point enumerator
        //

        public enum CompassPoint { N, W, E, S }

        //
        // Get/set the precision to be applied to calculated 
        // values (mostly dealing withe the Value property).
        //

        public int Precision { get; set; }

        //
        // Get/set the actual value of this coordintae part. 
        // This value is used to determine  degrees/minutes
        // seconds when they're needed.
        //

        public double Value { get; set; }

        //
        // The compass point represented by this coordinate part.
        //

        public CompassPoint Direction { get; set; }

        //
        // Gets the radians represented by the Value
        //

        public double Radians
        {
            get { return Math.Round(GpsMath.DegreeToRadian(Value), this.Precision); }
        }

        //
        // Gets the degrees rpresented by the Value.
        //

        public double Degrees
        {
            get { return Math.Round(GpsMath.RadianToDegree(Value), this.Precision); }
        }

        //
        // CONSTRUCTORS
        //

        public LatLongBase(int degs, int mins, double secs) : this(degs, mins, secs, DEFAULT_MATH_PRECISION) { }

        public LatLongBase(int degs, int mins, double secs, int mathPrecision)
        {
            SanityCheck(degs, mins, secs, mathPrecision);
            Precision = mathPrecision;
            DmsToValue(degs, mins, secs);
            SetDirection();
        }

        public LatLongBase(int degs, double mins) : this(degs, mins, DEFAULT_MATH_PRECISION) { }

        public LatLongBase(int degs, double mins, int mathPrecision)
        {
            SanityCheck(degs, mins, mathPrecision);
            Precision = mathPrecision;
            int tempMins = (int)(Math.Floor(mins));
            double secs = 60d * (mins - tempMins);
            DmsToValue(degs, tempMins, secs);
            SetDirection();
        }

        public LatLongBase(double value) : this(value, DEFAULT_MATH_PRECISION) { }

        public LatLongBase(double value, int mathPrecision)
        {
            SanityCheck(value, mathPrecision);
            Precision = mathPrecision;
            Value = value;
            SetDirection();
        }

        //
        // Convert the specified string to a coordinate component. 
        // @param coord The coordinate as a string. Can be in one of the following formats 
        // (where X is the appropriate compass point and the minus is used to indicate W or S 
        // compass poiints):
        //     - [X][-]dd mm ss.s 
        //     - [X][-]dd* mm' ss.s" 
        //     - [X][-]dd mm.m (degrees minutes.percentage of minute)
        //     - [X][-]dd.d (degrees)        
        // @param mathPrecision Precision used for math calculations.
        //

        public LatLongBase(string coord) : this(coord, DEFAULT_MATH_PRECISION) { }

        public LatLongBase(string coord, int mathPrecision)
        {
            // 
            // 1st sanity check - make sure the string isn't empty
            //

            SanityCheck(coord, mathPrecision);
            Precision = mathPrecision;

            //
            // Convert compass points to their appropriate sign - for easier manipulation, we remove 
            // the compass points and if necessary, replace with a minus sign to indicate the 
            // appropriate direction.
            //

            coord = coord.ToUpper(CultureInfo.InvariantCulture);
            coord = AdjustCoordDirection(coord);

            //
            // Get rid of the expected segment markers (degree, minute, and second symbols) and 
            // trim off any whitespace.
            //

            coord = coord.Replace("\"", "").Replace("'", "").Replace(GpsMath.DEGREE_SYMBOL, "").Trim();

            //
            // 2nd sanity check - Now that we've stripped all the unwanted stuff from the string, 
            // let's make sure we still have a string with content.
            //

            SanityCheckString(coord);

            // 
            // Split the string at space characters
            //

            string[] parts = coord.Split(' ');
            bool valid = false;
            int degs = 0;
            int mins = 0;
            double secs = 0d;

            // 
            // Depending on how many "parts" there are in the string, we try to parse the value(s).
            //

            switch (parts.Length)
            {
                case 1:
                    {
                        //
                        // Assume that the part is a double value. that can merely be parsed and 
                        // assigned to the Value property.
                        //

                        double value;
                        if (double.TryParse(coord, out value))
                        {
                            SanityCheck(value, mathPrecision);
                            Value = value;
                        }
                        else
                        {
                            throw new ArgumentException("Could not parse coordinate value. Expected degreees (decimal).");
                        }
                    }
                    break;
                case 2:
                    {
                        //
                        // Assume that the parts are "degrees minutes". 
                        //

                        double minsTemp = 0d;
                        for (int i = 0; i < parts.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    {
                                        valid = (int.TryParse(parts[i], out degs));
                                    }
                                    break;
                                case 1:
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
                            // 
                            // if the values parsed as expected, we need to separate the minutes from the seconds.
                            //

                            mins = (int)(Math.Floor(minsTemp));
                            secs = Math.Round(60d * (minsTemp - mins), 3);
                            SanityCheck(degs, mins, secs, 3);
                        }
                    }
                    break;
                case 3:
                    {
                        //
                        // Assume that the parts are "degrees minutes seconds". 
                        //

                        for (int i = 0; i < parts.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    {
                                        valid = (int.TryParse(parts[i], out degs));
                                    }
                                    break;
                                case 1:
                                    {
                                        valid = (int.TryParse(parts[i], out mins));
                                    }
                                    break;
                                case 2:
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
                            SanityCheck(degs, mins, secs, mathPrecision);
                        }
                    }
                    break;
            }

            //
            // If everything is valid and our we had more than one parameter, convert the parsed 
            // degrees, minutes, and seconds, and assign the result to the Value property, and 
            // finally, set the compass point.
            //

            if (valid && parts.Length > 1)
            {
                DmsToValue(degs, mins, secs);
                SetDirection();
            }
        }

        //
        // HELPER METHODS
        //

        //
        // Returns the Value of this object as a GPS coordinate part.
        // @param format
        // @returns
        // @remarks
        // Valid format string values (anything else will generate an exception). If a null/empty 
        // string is specified, the "DA" format will be used.
        //     - DA = "N0* 0' 0"", where N indicates the appropriate direction at the BEGINNING of the string
        //     - da = "-0* 0' 0"", where "-" is prepended if the coordinate part is either west or south
        //     - AD = "0* 0' 0"N", where N indicates the appropriate direction at the END of the string
        //     - DV = "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
        //     - dv = "-0.00000", where "-" is prepended if the coordinate part is either west or south
        //     - VD = "0.00000N", where N indicates the appropriate direction at the END of the string
        //

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "DA";
            }
            string result = string.Empty;
            switch (format)
            {
                case "DA": // "N0* 0' 0"" where N indicates the appropriate direction at the BEGINNING of the string
                case "da": // "-0* 0' 0"", where "-" is prepended if the coordinate part is either west or south
                    {
                        result = AppendDirection(FormatAsDms(), format);
                    }
                    break;
                case "AD": // "0* 0' 0"N", where N indicates the appropriate direction at the END of the string
                    {
                        result = AppendDirection(FormatAsDms(), format);
                    }
                    break;

                case "DV": // "N0.00000", where N indicates the appropriate direction at the BEGINNING of the string
                case "dv": // "-0.00000", where "-" is prepended if the coordinate part is either west or south
                    {
                        result = AppendDirection(string.Format("{0:0.00000}", Value), format);
                    }
                    break;
                case "VD": // "0.00000N", where N indicates the appropriate direction at the END of the string
                    {
                        result = AppendDirection(string.Format("{0:0.00000}", Value), format);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid GPS coordinate string format");
            }
            return result;
        }

        //
        // Converts the current Value to degrees/minutes/seconds, and returns those calculated 
        // values via the "out" properties.
        // @param degs The calculated degrees.
        // @param mins The calculated minutes.
        // @param secs The calculated seconds.
        //

        private void ValueToDms(out int degs, out int mins, out double secs)
        {
            degs = (int)Value;
            secs = (Math.Abs(Value) * 3600) % 3600;
            mins = (int)(Math.Abs(secs / 60d));
            secs = Math.Round(secs % 60d, 3);
        }

        //
        // Converts the specified degrees/minutes/seconds to a single value, 
        // and sets the Value property.
        // @param degs The degrees.
        // @param mins The minutes
        // @param secs The seconds
        //

        private void DmsToValue(int degs, int mins, double secs)
        {
            double adjuster = (degs < 0) ? -1d : 1d;
            Value = Math.Round((Math.Abs(degs) + (mins / 60d) + (secs / 3600d)) * adjuster, this.Precision);
        }

        //
        // Formats a string using the degrees, minutes and seconds of the coordinate.
        // @returns A string formatted as "0* 0' 0"".
        //

        private string FormatAsDms()
        {
            int degs;
            int mins;
            double secs;
            ValueToDms(out degs, out mins, out secs);
            return string.Format("{0}{1} {2}' {3}\"", Math.Abs(degs), GpsMath.DEGREE_SYMBOL, mins, secs);
        }

        //
        // Appends either the compass point, or a minus symbol (if appropriate, and indicated by the specified format).
        // @param coord The coordinate string.
        // @param format The format indicator
        // @returns The adjusted coordinate string
        //

        private string AppendDirection(string coord, string format)
        {
            string result = string.Empty;
            switch (format)
            {
                case "da":
                case "dv":
                    result = string.Concat("-", coord);
                    break;
                case "DA":
                case "DV":
                    result = string.Concat(this.Direction.ToString(), coord.Replace("-", ""));
                    break;
                case "AD":
                case "VD":
                    result = string.Concat(coord, this.Direction.ToString());
                    break;
            }
            return result;
        }

        //
        // ABSTRACT METHODS
        //

        //
        // Sets the directionType for this object based on whether this object is a latitude or a 
        // longitude, and the Value of the coordinate.
        //

        protected abstract void SetDirection();

        //
        // Adjusts the direction based on whether this is a latitude or longitude
        // @param coord The string coordinate
        // @return The adjusted coordinate string
        //

        protected abstract string AdjustCoordDirection(string coord);

        //
        // Gets the maximum value of the degrees based on whether or 
        // not this is a latitude or longitude.
        // @returns The maximum allowed degrees.
        //

        protected abstract int GetMaxDegrees();

        //
        // SANITY CHECKS
        //

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

            SanityCheckPrecision(mathPrecision);
        }

        private void SanityCheck(int degs, double mins, int mathPrecision)
        {
            int maxDegrees = GetMaxDegrees();
            int minDegrees = maxDegrees * -1;

            if (degs < minDegrees || degs > maxDegrees)
            {
                throw new ArgumentException(string.Format("Degrees MUST be {0} - {1}", minDegrees, maxDegrees));
            }
            if (mins < 0d || mins > 60d)
            {
                throw new ArgumentException("Minutes MUST be 0.0 - 60.0");
            }

            SanityCheckPrecision(mathPrecision);
        }

        private void SanityCheck(double value, int mathPrecision)
        {
            double maxValue = (double)this.GetMaxDegrees();
            double minValue = maxValue * -1;

            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(string.Format("Degrees MUST be {0} - {1}", minValue, maxValue));
            }

            SanityCheckPrecision(mathPrecision);
        }

        private void SanityCheck(string coord, int mathPrecision)
        {
            SanityCheckString(coord);
            SanityCheckPrecision(mathPrecision);
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
            //
            // You can have a maximum of 17 digits to the right of the decimal point in a double 
            // value, but when you do ANY math on the value, the 17th digit may or may not reflect 
            // the actual value (research math and equality on doubles for more info). For this 
            // reason, I recommend using a precision value of nothing higher than 16. The default 
            // value is 6.
            //

            if (mathPrecision < 0 || mathPrecision > 17)
            {
                throw new ArgumentException("Math precision MUST be 0 - 17");
            }
        }
    }
}
