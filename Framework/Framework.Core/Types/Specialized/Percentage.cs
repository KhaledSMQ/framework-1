// ============================================================================
// Project: Framework
// Name/Class: Percentage
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Percentage datatype.
// ============================================================================

using System;
using System.Globalization;
using Framework.Core.Extensions;

namespace Framework.Core.Types.Specialized
{
    public class Percentage
    {
        //
        // PROPERTIES
        //

        //
        // Value for the percentage.
        // This should be a number between 0.0 and 1.0.
        //

        public double Value
        {
            get { return __Value; }
            set { SetValue(value); }
        }

        //
        // CONSTRUCTORS
        //

        public Percentage()
        {
            Value = 0.0f;
        }

        public Percentage(int value)
        {
            SetValue(value);
        }

        public Percentage(double value)
        {
            SetValue(value);
        }

        //
        // Create a new percentage value. The string value to be valid 
        // must be one of: If it ends with a % symbol, then the value 
        // must be between 0 and 100. If that symbol is not found, the 
        // value must be a double value between 0.0 and 1.0.
        // @param value The string value for the percentage.
        //

        public Percentage(string value)
        {
            SetValue(value);
        }

        public Percentage(string value, CultureInfo cult)
        {
            SetValue(value, cult);
        }

        //
        // Set the value of the internal percentage container.
        // Use a integer value.
        //

        protected void SetValue(int value)
        {
            if ((value >= 0) && (value <= 100))
            {
                __Value = value / 100;
            }
            else
            {
                throw new Exception(string.Format("percentage value '{0}' is invalid!, should be >= 0 and <= 100", value));
            }
        }

        //
        // Set the value of the internal percentage container.
        // Use a double value.
        //

        protected void SetValue(double value)
        {
            if ((value >= 0.0f) && (value <= 1.0f))
            {
                __Value = value;
            }
            else
            {
                throw new Exception(string.Format("percentage value '{0}' is invalid!, should be >= 0.0 and <= 1.0", value));
            }
        }

        //
        // Set the value of the internal percentage container.
        // Use a string value.
        //

        protected void SetValue(string value)
        {
            SetValue(value, CultureInfo.CurrentCulture);
        }

        protected void SetValue(string value, CultureInfo cult)
        {
            double dblValue = 0.0f;

            // 
            // Check if it has a percentage symbol at the end
            //

            if (value[value.Length - 1] == '%')
            {
                string str = value.ChopEnd(1);
                if (double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, cult.NumberFormat, out dblValue))
                {
                    if ((dblValue >= 0) && (dblValue <= 100))
                    {
                        dblValue = ((double)dblValue) / 100;
                    }
                    else
                    {
                        throw new Exception("invalid percentage value '" + dblValue + "', should be >= 0 and <= 100");
                    }
                }
                else
                {
                    throw new Exception("invalid percentage value '" + value + "'");
                }
            }
            else
            {
                if (double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, cult.NumberFormat, out dblValue))
                {
                    if ((dblValue >= 0) && (dblValue < 1.0f))
                    {

                    }
                    else
                    {
                        throw new Exception("invalid percentage value '" + dblValue + "', should be >= 0.0 and <= 1.0");
                    }
                }
                else
                {
                    throw new Exception("invalid percentage value '" + value + "'");
                }
            }

            SetValue(dblValue);
        }

        //
        // Generate a human readable string value for 
        // this percentage  object instance.       
        // @return The percentage value as a human readable value.
        //

        public string ToHuman()
        {
            return ToHuman(true);
        }

        //
        // Generate a human readable string value for 
        // this percentage object instance.
        // @param percentageSymbol Attach the percentage symbol at end?
        // @return The percentage value as a human readable value.
        //

        public string ToHuman(bool percentageSymbol = true)
        {
            return (__Value * 100).ToString("F3") + (percentageSymbol ? "%" : string.Empty);
        }

        //
        // String representation of the percentage object instance.
        // This is the basic string representation., it should return a 
        // value between 0.0 and 1.0.
        // @return The string value for the percentage object instance.
        //

        public override string ToString()
        {
            return __Value.ToString();
        }

        //
        // Clone this percentage object instance.
        // This method will return a new reference for 
        // a percentage object instance in all will have
        // the same value.
        // @return The cloned percentage value.
        //

        public Percentage Clone()
        {
            return new Percentage(Value);
        }

        //
        // INTERNAL PROPERTIES
        // 

        private double __Value = 0.0f;

        //
        // STATICS
        //

        //
        // Static method to convert a integer value to a percentage
        // object instance. The integer value must be between 0 and 100
        // (inclusive).
        // @param value the integer value to use
        // @return The percentage object instance.
        //

        public static Percentage FromInt(int value)
        {
            return new Percentage(value);
        }

        //
        // Static method to convert a double value to a percentage
        // object instance. The double value must be between 0.0 and 1.0
        // (inclusive).
        // @param value the double value to use.
        // @return The percentage object instance.
        //

        public static Percentage FromDouble(double value)
        {
            return new Percentage(value);
        }

        //
        // Static method to convert a string value to a percentage
        // object instance. The string value to be valid must be one 
        // of: If it ends with a % symbol, then the value must be
        // between 0 and 100. If that symbol is not found, the value
        // must be a double value between 0.0 and 1.0.
        // @param value The string value to use.
        // @return The percentage object instance
        //

        public static Percentage FromString(string value)
        {
            return new Percentage(value);
        }

        public static Percentage FromString(string value, CultureInfo cult)
        {
            return new Percentage(value, cult);
        }
    }
}
