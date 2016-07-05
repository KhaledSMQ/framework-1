// ============================================================================
// Project: Framework
// Name/Class: MathHelper
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Math util functions.
// ============================================================================

using System;

namespace Framework.Core.Helpers
{
    public static class MathHelper
    {
        //
        // INT
        //

        public static int IntLength(int i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();

            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 48);
            }
            return (char)((n - 10) + 97);
        }

        public static int? Min(int? val1, int? val2)
        {
            if (val1 == null)
                return val2;
            if (val2 == null)
                return val1;

            return Math.Min(val1.Value, val2.Value);
        }

        public static int? Max(int? val1, int? val2)
        {
            if (val1 == null)
                return val2;
            if (val2 == null)
                return val1;

            return Math.Max(val1.Value, val2.Value);
        }

        //
        // DOUBLE
        //

        public static double? Max(double? val1, double? val2)
        {
            if (val1 == null)
                return val2;
            if (val2 == null)
                return val1;

            return Math.Max(val1.Value, val2.Value);
        }

        public static bool ApproxEquals(double d1, double d2)
        {
            // 
            // Are values equal to within 6 (or so) digits of precision?
            //

            return Math.Abs(d1 - d2) < (Math.Abs(d1) * 1e-6);
        }

        public static bool ApproxEquals(double d1, double d2, int ndigits)
        {
            // 
            // Are values equal to within a specific number of digits of precision?
            //

            return Math.Abs(d1 - d2) < (Math.Abs(d1) * 1e-6);
        }
    }
}