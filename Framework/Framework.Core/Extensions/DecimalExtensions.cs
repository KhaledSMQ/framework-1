// ============================================================================
// Project: Framework
// Name/Class: DecimalExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Decimal extensions.
// ============================================================================

using System;

namespace Framework.Core.Extensions
{
    public static class DecimalExtensions
    {
        //
        // Method that finds a digit at an arbirary position of a decimal.
        //

        public static int DigitAtPosition(this decimal number, int position)
        {
            if (position <= 0)
            {
                throw new ArgumentException("Position must be positive.");
            }

            if (number < 0)
            {
                number = Math.Abs(number);
            }

            return number.SanitizedDigitAtPosition(position);
        }

        private static int SanitizedDigitAtPosition(this decimal sanitizedNumber, int validPosition)
        {
            sanitizedNumber -= Math.Floor(sanitizedNumber);

            if (sanitizedNumber == 0)
            {
                return 0;
            }

            if (validPosition == 1)
            {
                return (int)(sanitizedNumber * 10);
            }

            return (sanitizedNumber * 10).SanitizedDigitAtPosition(validPosition - 1);
        }

        //
        // Returns a specified decimal number to a specified power. This method
        // performs slower than the Math.Pow() method, but in some circumstances
        // it is more accurate.
        //

        public static decimal Pow(this decimal number, decimal exponent)
        {
            // 
            // An exponent value of 0 will always return 1
            //

            if (exponent == 0)
            {
                return 1;
            }

            //
            // If the base value we are multiplying against is 0 or 1, the
            // result will always be the value.
            //

            if (number == 0 || number == 1)
            {
                return number;
            }

            //
            // Test to see if the exponent is a whole number or not, 
            // if so we can calculate the exponent using higher-precision math 
            // than the Math.Pow method. 
            //

            var result = number;

            // --== DECIMAL CASE ==--

            //
            // Math is hard. For fractional exponents, we just use the relatively
            // impercise Math.Pow() and cast to decimal.
            // TODO: Determine how to do this operation with greater percision 
            //

            if (Math.Truncate(exponent) < exponent)
            {
                return new decimal(Math.Pow(Decimal.ToDouble(number), Decimal.ToDouble(exponent)));
            }

            //
            // --== POSITIVE CASE ==--
            // In order to compute negative exponents, we need to be able
            // to compute the power as a positive number.
            //

            var power = exponent < 0 ? Math.Abs(exponent) : exponent;

            for (var i = 1; i < power; i++)
            {
                result *= number;
            }

            //
            // Return positive exponents now because we have already obtained their results.
            //

            if (exponent > 0)
            {
                return result;
            }

            // --== NEGATIVE CASE ==--

            //
            // Otherwise, we are computing a negative exponent.
            // Using the following formula: x^-2 = 1/x^2. Note, we needed
            // the value from the positive case to compute the negative case. 
            //

            return 1m / result;
        }

        //
        // Gets the number of decimal places of a decimal.
        // Documentation at: http://msdn.microsoft.com/en-us/library/system.decimal.getbits(v=vs.100).aspx
        //

        public static int GetDecimalPlaces(this decimal value)
        {
            return (decimal.GetBits(value)[3] & 0xFF0000) >> 16;
        }
    }
}