// ============================================================================
// Project: Framework
// Name/Class: StringExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension methods for string datatype.
// ============================================================================                    

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Framework.Core.Types.Specialized;
using Framework.Core.Helpers;

namespace Framework.Core.Extensions
{
    public static class StringExtensions
    {
        //
        // Check a certain string if its an email address.
        // Return true is string is a valid email address.
        //

        public static bool IsEmail(this string str)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
            return re.IsMatch(str);
        }

        // 
        // Check is a certain string is a valid Guid.
        // Return true is a string is a valid GUID.
        // 

        public static bool IsGuid(this string str)
        {
            string strRegex = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
            Regex re = new Regex(strRegex, RegexOptions.Compiled);
            return re.IsMatch(str);
        }

        //
        // Split the string by a certain set of characters.
        // Returns the list of strings split by the input characters.
        //

        public static string[] Split(this string str, StringSplitOptions opt, params char[] sep)
        {
            return str.Split(sep, opt);
        }

        //
        // Split a string using a set of characters, but removing all empty parcels.
        // Returns the list of strings split by the input characters.
        //

        public static string[] SplitNoEmpty(this string str, params char[] sep)
        {
            return str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        // 
        // Split a string using a set of strings, but removing all empty parcels.
        // Returns the list of strings split by the inputs strings.
        //

        public static string[] SplitNoEmpty(this string str, params string[] sep)
        {
            return str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        //
        // Check if a string is null or empty.
        // Returns true is string is null or empty, or false otherwise.        
        //

        public static bool isNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        //
        // Check if a string is not null and not empty. Return true is string has an efective
        // value, or false if it is null or empty
        // Returns true is string is not null and not empty, false otherwise.
        //

        public static bool isNotNullAndEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        //
        // Chop, i.e., remove from the start of a string a certain number of
        // characters. The number of characters to remove is compared with
        // the length os string, so that no overbound state is reached
        // Returns the input string without the chopped characters
        //

        public static string ChopStart(this string str, int n)
        {
            return str.Substring(Math.Min(n, str.Length));
        }

        //
        // Chop, i.e. remove, from the end of a string a certain number of characters
        // the number of characters to remove is compared with the length of the
        // string, so that no overbound state is reached
        // Returns the input string without the chopped characters
        //

        public static string ChopEnd(this string str, int n)
        {
            return str.Substring(0, str.Length - Math.Min(n, str.Length));
        }

        //
        // Get the string characters after a certain character.
        // Only applies to the first occurence of the supplied character.
        // if character does not exist, return the emty string.
        // Returns the string that starts after the supplied character.
        //

        public static string After(this string str, char c)
        {
            int index = str.IndexOf(c);
            return index >= 0 ? str.ChopStart(str.IndexOf(c) + 1) : string.Empty;
        }

        //
        // STRING PARSING METHODS
        //

        #region String Parsing Methods

        private const bool REQUIRED_VALUE = true;
        private const bool OPTIONAL_VALUE = false;

        //
        // STRINGS
        //

        //
        // TODO: Remove the name parameter.
        //

        public static string ParseOptionalValue_String(this string value, string name, string defaultValue, CultureInfo cult, Func<string, CultureInfo, string> parseDelegate)
        {
            return value.ParseValue<string>(OPTIONAL_VALUE, default(string), cult, parseDelegate);
        }

        public static string ParseOptionalValue_String(this string value, string name, string defaultValue, Func<string, string> parseDelegate)
        {
            return value.ParseValue<string>(OPTIONAL_VALUE, default(string), parseDelegate);
        }

        // Optional

        public static string ParseOptionalValue_String(this string value, string dftValue, Func<string, string> parseDelegate)
        {
            return value.ParseValue<string>(OPTIONAL_VALUE, dftValue, parseDelegate);
        }

        public static string ParseOptionalValue_String(this string value, string dftValue, string cult, Func<string, CultureInfo, string> parseDelegate)
        {
            return value.ParseValue<string>(OPTIONAL_VALUE, dftValue, new CultureInfo(cult), parseDelegate);
        }

        public static string ParseOptionalValue_String(this string value, string dftValue, CultureInfo cult, Func<string, CultureInfo, string> parseDelegate)
        {
            return value.ParseValue<string>(OPTIONAL_VALUE, dftValue, cult, parseDelegate);
        }

        // Required

        public static string ParseRequiredValue_String(this string value, Func<string, string> parseDelegate)
        {
            return value.ParseValue<string>(REQUIRED_VALUE, default(string), parseDelegate);
        }

        public static string ParseRequiredValue_String(this string value, string cult, Func<string, CultureInfo, string> parseDelegate)
        {
            return value.ParseValue<string>(REQUIRED_VALUE, default(string), new CultureInfo(cult), parseDelegate);
        }

        public static string ParseRequiredValue_String(this string value, CultureInfo cult, Func<string, CultureInfo, string> parseDelegate)
        {
            return value.ParseValue<string>(REQUIRED_VALUE, default(string), cult, parseDelegate);
        }

        //
        // SETS
        //

        public static R ParseRequiredValue_Set<R>(this string value, params object[] set)
        {
            return value.ParseValue_Set<R>(REQUIRED_VALUE, default(R), true, set);
        }

        public static R ParseOptionalValue_Set<R>(this string value, R defaultValue, params object[] set)
        {
            return value.ParseValue_Set<R>(OPTIONAL_VALUE, defaultValue, true, set);
        }

        //
        // DOUBLES
        //

        // Optional

        public static double ParseOptionalValue_Double(this string value, double dftValue)
        {
            return value.ParseValue<double>(OPTIONAL_VALUE, dftValue, CultureInfo.CurrentCulture, (s, c) => Double.Parse(s, c.NumberFormat));
        }

        public static double ParseOptionalValue_Double(this string value, double dftValue, string cult)
        {
            return value.ParseValue<double>(OPTIONAL_VALUE, dftValue, new CultureInfo(cult), (s, c) => Double.Parse(s, c.NumberFormat));
        }

        public static double ParseOptionalValue_Double(this string value, double dftValue, CultureInfo cult)
        {
            return value.ParseValue<double>(OPTIONAL_VALUE, dftValue, cult, (s, c) => Double.Parse(s, c.NumberFormat));
        }

        // Required

        public static double ParseRequiredValue_Double(this string value)
        {
            return value.ParseValue<double>(REQUIRED_VALUE, default(double), CultureInfo.CurrentCulture, (s, c) => Double.Parse(s, c.NumberFormat));
        }

        public static double ParseRequiredValue_Double(this string value, string cult)
        {
            return value.ParseValue<double>(REQUIRED_VALUE, default(double), new CultureInfo(cult), (s, c) => Double.Parse(s, c.NumberFormat));
        }

        public static double ParseRequiredValue_Double(this string value, CultureInfo cult)
        {
            return value.ParseValue<double>(REQUIRED_VALUE, default(double), cult, (s, c) => Double.Parse(s, c.NumberFormat));
        }

        //
        // BOOLEANS
        //

        // Optional

        public static bool ParseOptionalValue_YesNo(this string value, bool defaultValue)
        {
            return value.ParseValue<bool>(OPTIONAL_VALUE, default(bool), Convert.ToBoolean);
        }

        public static bool ParseOptionalValue_Bool(this string value, bool defaultValue)
        {
            return value.ParseValue<bool>(OPTIONAL_VALUE, default(bool), Convert.ToBoolean);
        }

        // Required

        public static bool ParseRequiredValue_YesNo(this string value)
        {
            return value.ParseValue<bool>(REQUIRED_VALUE, default(bool), Convert.ToBoolean);
        }

        public static bool ParseRequiredValue_Bool(this string value)
        {
            return value.ParseValue<bool>(REQUIRED_VALUE, default(bool), Convert.ToBoolean);
        }

        //
        // INTEGERS
        //

        // Optional

        public static int ParseOptionalValue_Int(this string value, int dftValue)
        {
            return value.ParseValue<int>(OPTIONAL_VALUE, dftValue, CultureInfo.CurrentCulture, (s, c) => int.Parse(s, c.NumberFormat));
        }

        public static int ParseOptionalValue_Int(this string value, int dftValue, string cult)
        {
            return value.ParseValue<int>(OPTIONAL_VALUE, dftValue, new CultureInfo(cult), (s, c) => int.Parse(s, c.NumberFormat));
        }

        public static int ParseOptionalValue_Int(this string value, int dftValue, CultureInfo cult)
        {
            return value.ParseValue<int>(OPTIONAL_VALUE, dftValue, cult, (s, c) => int.Parse(s, c.NumberFormat));
        }

        // Required

        public static int ParseRequiredValue_Int(this string value)
        {
            return value.ParseValue<int>(REQUIRED_VALUE, default(int), CultureInfo.CurrentCulture, (s, c) => int.Parse(s, c.NumberFormat));
        }

        public static int ParseRequiredValue_Int(this string value, string cult)
        {
            return value.ParseValue<int>(REQUIRED_VALUE, default(int), new CultureInfo(cult), (s, c) => int.Parse(s, c.NumberFormat));
        }

        public static int ParseRequiredValue_Int(this string value, CultureInfo cult)
        {
            return value.ParseValue<int>(REQUIRED_VALUE, default(int), cult, (s, c) => int.Parse(s, c.NumberFormat));
        }

        // DATES

        // Optional

        public static DateTime ParseOptionalValue_DateTime(this string value, DateTime dftValue)
        {
            return value.ParseValue<DateTime>(OPTIONAL_VALUE, dftValue, CultureInfo.CurrentCulture, (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        public static DateTime ParseOptionalValue_DateTime(this string value, DateTime dftValue, string cult)
        {
            return value.ParseValue<DateTime>(OPTIONAL_VALUE, dftValue, new CultureInfo(cult), (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        public static DateTime ParseOptionalValue_DateTime(this string value, DateTime dftValue, CultureInfo cult)
        {
            return value.ParseValue<DateTime>(OPTIONAL_VALUE, dftValue, cult, (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        // Required

        public static DateTime ParseRequiredValue_DateTime(this string value)
        {
            return value.ParseValue<DateTime>(REQUIRED_VALUE, default(DateTime), CultureInfo.CurrentCulture, (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        public static DateTime ParseRequiredValue_DateTime(this string value, string cult)
        {
            return value.ParseValue<DateTime>(REQUIRED_VALUE, default(DateTime), new CultureInfo(cult), (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        public static DateTime ParseRequiredValue_DateTime(this string value, CultureInfo cult)
        {
            return value.ParseValue<DateTime>(REQUIRED_VALUE, default(DateTime), cult, (s, c) => DateTime.Parse(s, c.DateTimeFormat));
        }

        // PERCENTAGES

        // Optional

        public static Percentage ParseOptionalValue_Percentage(this string value, Percentage defaultValue)
        {
            return value.ParseValue<Percentage>(OPTIONAL_VALUE, defaultValue, Percentage.FromString);
        }

        public static Percentage ParseOptionalValue_Percentage(this string value, Percentage defaultValue, string cult)
        {
            return value.ParseValue<Percentage>(OPTIONAL_VALUE, defaultValue, new CultureInfo(cult), Percentage.FromString);
        }

        public static Percentage ParseOptionalValue_Percentage(this string value, Percentage defaultValue, CultureInfo cult)
        {
            return value.ParseValue<Percentage>(OPTIONAL_VALUE, defaultValue, cult, Percentage.FromString);
        }

        // Required

        public static Percentage ParseRequiredValue_Percentage(this string value)
        {
            return value.ParseValue<Percentage>(REQUIRED_VALUE, default(Percentage), Percentage.FromString);
        }

        public static Percentage ParseRequiredValue_Percentage(this string value, string cult)
        {
            return value.ParseValue<Percentage>(REQUIRED_VALUE, default(Percentage), new CultureInfo(cult), Percentage.FromString);
        }

        public static Percentage ParseRequiredValue_Percentage(this string value, CultureInfo cult)
        {
            return value.ParseValue<Percentage>(REQUIRED_VALUE, default(Percentage), cult, Percentage.FromString);
        }

        //
        // DECIMAL
        //

        // Optional

        public static decimal ParseOptionalValue_Decimal(this string value, decimal dftValue)
        {
            return value.ParseValue<decimal>(OPTIONAL_VALUE, dftValue, CultureInfo.CurrentCulture, (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        public static decimal ParseOptionalValue_Decimal(this string value, decimal dftValue, string cult)
        {
            return value.ParseValue<decimal>(OPTIONAL_VALUE, dftValue, new CultureInfo(cult), (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        public static decimal ParseOptionalValue_Decimal(this string value, decimal dftValue, CultureInfo cult)
        {
            return value.ParseValue<decimal>(OPTIONAL_VALUE, dftValue, cult, (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        // Required

        public static decimal ParseRequiredValue_Decimal(this string value)
        {
            return value.ParseValue<decimal>(REQUIRED_VALUE, default(decimal), CultureInfo.CurrentCulture, (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        public static decimal ParseRequiredValue_Decimal(this string value, string cult)
        {
            return value.ParseValue<decimal>(REQUIRED_VALUE, default(decimal), new CultureInfo(cult), (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        public static decimal ParseRequiredValue_Decimal(this string value, CultureInfo cult)
        {
            return value.ParseValue<decimal>(REQUIRED_VALUE, default(decimal), cult, (s, c) => Decimal.Parse(s, c.NumberFormat));
        }

        // GENERICS

        public static R ParseValue<R>(this string value, bool required, R defaultValue, Func<string, R> parseDelegate)
        {
            return value.ParseValue<R>(required, defaultValue, CultureInfo.CurrentCulture, (s, c) => parseDelegate(s));
        }

        public static R ParseValue<R>(this string value, bool required, R defaultValue, CultureInfo cult, Func<string, CultureInfo, R> parseDelegate)
        {
            R output = defaultValue;
            if (string.IsNullOrEmpty(value))
            {
                if (required)
                {
                    throw new Exception("value is required, but has an empty/null value!");
                }
            }
            else
            {
                output = parseDelegate(value, cult);
            }

            return output;
        }

        public static R ParseValue_Set<R>(this string value, bool required, R defaultValue, bool insensitive, params object[] set)
        {
            // set the string comparison value based on input parameter
            StringComparison strComp = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            // flag that says if a valid value was found
            bool found = false;

            // set up return value
            R retValue = defaultValue;

            // try to parse the value
            string trimmed = value.Trim();
            for (int i = 0; i < set.Length; i += 2)
            {
                object param = set[i];
                if (param is string)
                {
                    string input = param as string;
                    if (String.Compare(input, trimmed, strComp) == 0)
                    {
                        // found one of the string values to be parse, now try to get the value itself
                        if (i + 1 < set.Length)
                        {
                            retValue = (R)set[i + 1];
                            found = true;
                            break;
                        }
                        else
                        {
                            throw new Exception(String.Format("Invalid set in parser, the value of string {0} was not found", input));
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid set in parser, event elements must be of type string");
                }
            }

            // if this value is required and is not found, flag an error
            if (!found && required)
            {
                throw new Exception("value is required, but no match was found!");
            }

            return retValue;
        }

        public static IDictionary<string, string> ParseDictionary(this string str, char propSep, char nameValueSep)
        {
            // parse the property values
            SortedDictionary<string, string> ast = new SortedDictionary<string, string>();

            string trimmed = str.Trim();
            string[] pairNameValue = trimmed.SplitNoEmpty(propSep);

            foreach (string nameValue in pairNameValue)
            {
                string[] property = nameValue.SplitNoEmpty(nameValueSep);

                if (property.Length >= 2)
                {
                    string name = property[0].Trim();
                    string value = property[1].Trim();
                    ast.Add(name, value);
                }
                else
                {
                    throw new Exception("parsing error in string property values");
                }
            }

            // return the prioperty value set
            return ast;
        }

        public static IDictionary<string, string> ParseDictionaryFreely(this string str, char propSep, char nameValueSep)
        {
            // parse the property values
            SortedDictionary<string, string> ast = new SortedDictionary<string, string>();

            string trimmed = str.Trim();
            string[] pairNameValue = trimmed.SplitNoEmpty(propSep);

            foreach (string nameValue in pairNameValue)
            {
                string[] property = nameValue.SplitNoEmpty(nameValueSep);

                string name = string.Empty;
                string value = string.Empty;

                switch (property.Length)
                {
                    case 0:
                        {
                            throw new Exception("Run for the hills!");
                        }
                    case 1:
                        {
                            name = property[0].Trim();
                        }
                        break;
                    case 2:
                        {
                            name = property[0].Trim();
                            value = property[1].Trim();
                        }
                        break;
                    default:
                        {
                            name = property[0].Trim();
                            value = property.Join(new String(nameValueSep, 1), 1);
                        }
                        break;
                }

                ast.Add(name, value);

            }

            // return the prioperty value set
            return ast;
        }
        #endregion

        #region Appending
        /// <summary>
        /// Multiply a string N number of times.
        /// </summary>
        /// <param name="str">String to multiply.</param>
        /// <param name="times">Number of times to multiply the string.</param>
        /// <returns>Original string multiplied N times.</returns>
        public static string Times(this string str, int times)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            if (times <= 1) return str;

            string strfinal = string.Empty;
            for (int ndx = 0; ndx < times; ndx++)
                strfinal += str;

            return strfinal;
        }


        /// <summary>
        /// Increases the string to the maximum length specified.
        /// If the string is already greater than maxlength, it is truncated if the flag truncate is true.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="truncate">if set to <c>true</c> [truncate].</param>
        /// <returns>Increased string.</returns>
        public static string IncreaseTo(this string str, int maxLength, bool truncate)
        {
            if (string.IsNullOrEmpty(str)) return str;
            if (str.Length == maxLength) return str;
            if (str.Length > maxLength && truncate) return str.Truncate(maxLength);

            string original = str;

            while (str.Length < maxLength)
            {
                // Still less after appending by original string.
                if (str.Length + original.Length < maxLength)
                {
                    str += original;
                }
                else // Append partial.
                {
                    str += str.Substring(0, maxLength - str.Length);
                }
            }
            return str;
        }


        /// <summary>
        /// Increases the string to the maximum length specified.
        /// If the string is already greater than maxlength, it is truncated if the flag truncate is true.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="minLength">String minimum length.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="truncate">if set to <c>true</c> [truncate].</param>
        /// <returns>Randomly increased string.</returns>
        public static string IncreaseRandomly(this string str, int minLength, int maxLength, bool truncate)
        {
            Random random = new Random(minLength);
            int randomMaxLength = random.Next(minLength, maxLength);
            return IncreaseTo(str, randomMaxLength, truncate);
        }
        #endregion

        #region Truncation
        /// <summary>
        /// Truncates the string.
        /// </summary>
        /// <param name="txt">String to truncate.</param>
        /// <param name="maxChars">Maximum string length.</param>
        /// <returns>Truncated string.</returns>
        public static string Truncate(this string txt, int maxChars)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;

            if (txt.Length <= maxChars)
                return txt;

            return txt.Substring(0, maxChars);
        }


        /// <summary>
        /// Truncate the text supplied by number of characters specified by <paramref name="maxChars"/>
        /// and then appends the suffix.
        /// </summary>
        /// <param name="txt">String to truncate.</param>
        /// <param name="maxChars">Maximum string length.</param>
        /// <param name="suffix">Suffix to append to string.</param>
        /// <returns>Truncated string with suffix.</returns>
        public static string TruncateWithText(this string txt, int maxChars, string suffix)
        {
            if (string.IsNullOrEmpty(txt))
                return txt;

            if (txt.Length <= maxChars)
                return txt;

            // Now do the truncate and more.
            string partial = txt.Substring(0, maxChars);
            return partial + suffix;
        }
        #endregion

        #region Conversion Methods

        //
        // CONVERSION METHODS -------------------------------------------------
        // String --> Bytes
        //

        //
        // Convert the text to bytes using the system default code page.
        // @param txt The string to convert.
        // @return The byte representation for the string.
        //

        public static byte[] ToBytes(this string txt)
        {
            return txt.ToBytesEncoding(System.Text.Encoding.Default);
        }

        //
        // Convert a string to bytes.
        // Use ASCII Encoding.
        // @param txt The string to convert.
        // @return The byte representation for the string.
        //

        public static byte[] ToBytesAscii(this string txt)
        {
            return txt.ToBytesEncoding(new System.Text.ASCIIEncoding());
        }

        //
        // Convert the text to bytes using a specified encoding.
        // @param txt The string to convert.
        // @param encoding The encoding to use.
        // @return The byte representation for the string.
        //

        public static byte[] ToBytesEncoding(this string txt, Encoding encoding)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return new byte[] { };
            }

            return encoding.GetBytes(txt);
        }

        //
        // Convert the text to bytes using no encoding.
        // @param txt The string to convert.
        // @return The byte representation for the string.
        //

        public static byte[] ToBytesNoEncoding(this string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //
        // CONVERSION METHODS -------------------------------------------------
        // Bytes --> String
        //

        public static string StringNoEncoding(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        //
        // Converts an ASCII byte array to a string.
        // @param bytes The ASCII bytes.
        // @return The string representation of ASCII bytes.
        //

        public static string StringFromBytesASCII(this byte[] bytes)
        {
            return bytes.StringFromBytesEncoding(new System.Text.ASCIIEncoding());
        }

        //
        // Converts a byte array to a string using the system default code page.
        // @param bytes The byte array.
        // @return The string representation of bytes.
        //

        public static string StringFromBytes(this byte[] bytes)
        {
            return bytes.StringFromBytesEncoding(System.Text.Encoding.Default);
        }

        //
        // Converts a byte array to a string using a specified encoding.
        // @param bytes The byte array.
        // @param encoding The encoding to use during the conversion.
        // @return The string representation of bytes.
        //

        public static string StringFromBytesEncoding(this byte[] bytes, Encoding encoding)
        {
            if (0 == bytes.GetLength(0))
            {
                return null;
            }

            return encoding.GetString(bytes);
        }

        /// <summary>
        /// Converts "yes/no/true/false/0/1"
        /// </summary>
        /// <param name="txt">String to convert to boolean.</param>
        /// <returns>Boolean converted from string.</returns>
        public static object ToBoolObject(this string txt)
        {
            return ToBool(txt) as object;
        }

        /// <summary>
        /// Converts "yes/no/true/false/0/1"
        /// </summary>
        /// <param name="txt">String to convert to boolean.</param>
        /// <returns>Boolean converted from string.</returns>
        public static bool ToBool(this string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return false;

            string trimed = txt.Trim().ToLower();
            if (trimed == "yes" || trimed == "true" || trimed == "1")
                return true;

            return false;
        }


        /// <summary>
        /// Converts a string to an integer and returns it as an object.
        /// </summary>
        /// <param name="txt">String to convert to integer.</param>
        /// <returns>Integer converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static object ToIntObject(this string txt)
        {
            return ToInt(txt) as object;
        }


        /// <summary>
        /// Converts a string to an integer.
        /// </summary>
        /// <param name="txt">String to convert to integer.</param>
        /// <returns>Integer converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static int ToInt(this string txt)
        {
            return ToNumber<int>(txt, (s) => Convert.ToInt32(Convert.ToDouble(s)), 0);
        }


        /// <summary>
        /// Converts a string to a long and returns it as an object.
        /// </summary>
        /// <param name="txt">String to convert to long.</param>
        /// <returns>Long converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static object ToLongObject(this string txt)
        {
            return ToLong(txt) as object;
        }


        /// <summary>
        /// Converts a string to a long.
        /// </summary>
        /// <param name="txt">String to convert to long.</param>
        /// <returns>Long converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static long ToLong(this string txt)
        {
            return ToNumber<long>(txt, (s) => Convert.ToInt64(s), 0);
        }


        /// <summary>
        /// Converts a string to a double and returns it as an object.
        /// </summary>
        /// <param name="txt">String to convert to double.</param>
        /// <returns>Double converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static object ToDoubleObject(this string txt)
        {
            return ToDouble(txt) as object;
        }


        /// <summary>
        /// Converts a string to a double.
        /// </summary>
        /// <param name="txt">String to convert from double.</param>
        /// <returns>Double converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static double ToDouble(this string txt)
        {
            return ToNumber<double>(txt, (s) => Convert.ToDouble(s), 0);
        }


        /// <summary>
        /// Converts a string to a float and returns it as an object.
        /// </summary>
        /// <param name="txt">String to convert to float.</param>
        /// <returns>Float converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static object ToFloatObject(this string txt)
        {
            return ToFloat(txt) as object;
        }


        /// <summary>
        /// Converts a string as a float and returns it.
        /// </summary>
        /// <param name="txt">String to convert to float.</param>
        /// <returns>Float converted from string.</returns>
        /// <remarks>The method takes into starting monetary symbols like $.</remarks>
        public static float ToFloat(this string txt)
        {
            return ToNumber<float>(txt, (s) => Convert.ToSingle(s), 0);
        }


        /// <summary>
        /// Converts a string to a decimal.
        /// </summary>
        /// <param name="txt">String to convert from decimal.</param>
        /// <returns>Decimal converted from string.</returns>
        public static decimal ToDecimal(this string txt)
        {
            return ToNumber<decimal>(txt, (s) => Convert.ToDecimal(s), decimal.Zero);
        }


        /// <summary>
        /// Converts to a number using the callback.
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="txt">String to convert.</param>
        /// <param name="callback">Conversion callback method.</param>
        /// <param name="defaultValue">Default conversion value.</param>
        /// <returns>Instance of type converted from string.</returns>
        public static T ToNumber<T>(string txt, Func<string, T> callback, T defaultValue)
        {
            if (string.IsNullOrEmpty(txt))
                return defaultValue;

            string trimed = txt.Trim().ToLower();
            // Parse $ or the system currency symbol.
            if (trimed.StartsWith("$") || trimed.StartsWith(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol))
            {
                trimed = trimed.Substring(1);
            }
            return callback(trimed);
        }

        #endregion

        //
        // HEXADECIMAL/BINARY METHODS
        //

        #region Hex and Binary
        /// <summary>
        /// Determines whether the string contains valid hexadecimal characters only.
        /// </summary>
        /// <param name="txt">String to check.</param>
        /// <returns>True if the string contains valid hexadecimal characters.</returns>
        /// <remarks>An empty or null string is considered to <b>not</b> contain
        /// valid hexadecimal characters.</remarks>
        public static bool IsHex(this string txt)
        {
            return (!txt.isNullOrEmpty()) && (txt.ReplaceChars("0123456789ABCDEFabcdef", "                      ").Trim().isNullOrEmpty());
        }


        /// <summary>
        /// Determines whether the string contains valid binary characters only.
        /// </summary>
        /// <param name="txt">String to check.</param>
        /// <returns>True if the string contains valid binary characters.</returns>
        /// <remarks>An empty or null string is considered to <b>not</b> contain
        /// valid binary characters.</remarks>
        public static bool IsBinary(this string txt)
        {
            return (!txt.isNullOrEmpty()) && (txt.ReplaceChars("01", "  ").Trim().isNullOrEmpty());
        }

        /// <summary>
        /// Returns the hexadecimal representation of a decimal number.
        /// </summary>
        /// <param name="txt">Hexadecimal string to convert to decimal.</param>
        /// <returns>Decimal representation of string.</returns>
        public static string DecimalToHex(this string txt)
        {
            return Convert.ToInt32(txt).ToHex();
        }


        /// <summary>
        /// Returns the binary representation of a binary number.
        /// </summary>
        /// <param name="txt">Decimal string to convert to binary.</param>
        /// <returns>Binary representation of string.</returns>
        public static string DecimalToBinary(this string txt)
        {
            return Convert.ToInt32(txt).ToBinary();
        }


        /// <summary>
        /// Returns the decimal representation of a hexadecimal number.
        /// </summary>
        /// <param name="txt">Hexadecimal string to convert to decimal.</param>
        /// <returns>Decimal representation of string.</returns>
        public static string HexToDecimal(this string txt)
        {
            return Convert.ToString(Convert.ToInt32(txt, 16));
        }


        /// <summary>
        /// Returns the binary representation of a hexadecimal number.
        /// </summary>
        /// <param name="txt">Binary string to convert to hexadecimal.</param>
        /// <returns>Hexadecimal representation of string.</returns>
        public static string HexToBinary(this string txt)
        {
            return Convert.ToString(Convert.ToInt32(txt, 16), 2);
        }


        /// <summary>
        /// Converts a hexadecimal string to a byte array representation.
        /// </summary>
        /// <param name="txt">Hexadecimal string to convert to byte array.</param>
        /// <returns>Byte array representation of the string.</returns>
        /// <remarks>The string is assumed to be of even size.</remarks>
        public static byte[] HexToByteArray(this string txt)
        {
            byte[] b = new byte[txt.Length / 2];
            for (int i = 0; i < txt.Length; i += 2)
            {
                b[i / 2] = Convert.ToByte(txt.Substring(i, 2), 16);
            }
            return b;
        }


        /// <summary>
        /// Converts a byte array to a hexadecimal string representation.
        /// </summary>
        /// <param name="b">Byte array to convert to hexadecimal string.</param>
        /// <returns>String representation of byte array.</returns>
        public static string ByteArrayToHex(this byte[] b)
        {
            return BitConverter.ToString(b).Replace("-", "");
        }


        /// <summary>
        /// Returns the hexadecimal representation of a binary number.
        /// </summary>
        /// <param name="txt">Binary string to convert to hexadecimal.</param>
        /// <returns>Hexadecimal representation of string.</returns>
        public static string BinaryToHex(this string txt)
        {
            return Convert.ToString(Convert.ToInt32(txt, 2), 16);
        }


        /// <summary>
        /// Returns the decimal representation of a binary number.
        /// </summary>
        /// <param name="txt">Binary string to convert to decimal.</param>
        /// <returns>Decimal representation of string.</returns>
        public static string BinaryToDecimal(this string txt)
        {
            return Convert.ToString(Convert.ToInt32(txt, 2));
        }
        #endregion

        #region Replacement

        /// <summary>
        /// Replaces the characters in the originalChars string with the
        /// corresponding characters of the newChars string.
        /// </summary>
        /// <param name="txt">String to operate on.</param>
        /// <param name="originalChars">String with original characters.</param>
        /// <param name="newChars">String with replacement characters.</param>
        /// <example>For an original string equal to "123456654321" and originalChars="35" and
        /// newChars "AB", the result will be "12A4B66B4A21".</example>
        /// <returns>String with replaced characters.</returns>
        public static string ReplaceChars(this string txt, string originalChars, string newChars)
        {
            string returned = "";

            for (int i = 0; i < txt.Length; i++)
            {
                int pos = originalChars.IndexOf(txt.Substring(i, 1));

                if (-1 != pos)
                    returned += newChars.Substring(pos, 1);
                else
                    returned += txt.Substring(i, 1);
            }
            return returned;
        }

        public static string ReplaceWithTable(this string input, string[] table)
        {
            int lenInput = input.Length;

            string replaced = input;
            for (int i = 0; i < table.Length; i = i + 2)
            {
                replaced = replaced.Replace(table[i], table[i + 1]);
            }

            int lenReplaced = replaced.Length;

            return replaced;
        }

        public static string replaceAccents(this string input)
        {
            /* á:&#225; Á:&#193; à:&#224; À:&#192; â:&#226; Â:&#194; å:&#229; Å:&#197; ã:&#227; Ã:&#195; ä:&#228; Ä:&#196; */
            string replaceAright = Regex.Replace(input, "&#225;|&#193;", "á");
            string replaceAleft = Regex.Replace(replaceAright, "&#224;|&#192;", "à");
            string replaceAcircumflex = Regex.Replace(replaceAleft, "&#226;|&#194;", "â");
            string replaceAball = Regex.Replace(replaceAcircumflex, "&#229;|&#197;", "å");
            string replaceAtil = Regex.Replace(replaceAball, "&#227;|&#195;", "ã");
            string replaceApoint = Regex.Replace(replaceAtil, "&#228;|&#196;", "ä");
            /*ç:&#231; Ç:&#199; */
            string replaceCedil = Regex.Replace(replaceApoint, "&#231;|&#199;", "ç");
            /* é:&#233; É:&#201; è:&#232; È:&#200; ê:&#234; Ê:&#202; ë:&#235; Ë:&#203; */
            string replaceEright = Regex.Replace(replaceApoint, "&#233;|&#201;", "é");
            string replaceEleft = Regex.Replace(replaceEright, "&#232;|&#200;", "è");
            string replaceEcircumflex = Regex.Replace(replaceEleft, "&#234;|&#202;", "ê");
            string replaceEpoint = Regex.Replace(replaceEcircumflex, "&#235;|&#203;", "ë");
            /* í:&#237; Í:&#205; ì:&#236; Ì:&#204; î:&#238; Î:&#206; ï:&#239; Ï:&#207; */
            string replaceI = Regex.Replace(replaceEpoint, "í|&#237;|Í|&#205;|ì|&#236;|Ì|&#204;|î|&#238;|Î|&#206;|ï|&#239;|Ï|&#207;", "i");
            /* ñ:&#241; Ñ:&#209; */
            string replaceN = Regex.Replace(replaceI, "&#241;|&#209;", "ñ");
            /* ó:&#243; Ó:&#211; ò:&#242; Ò:&#210; ô:&#244; Ô:&#212; ø:&#248; Ø:&#216; õ:&#245; Õ:&#213; ö:&#246; Ö:&#214; */
            string replaceOright = Regex.Replace(replaceN, "&#243;|&#211;", "ó");
            string replaceOleft = Regex.Replace(replaceOright, "&#242;|&#210;", "ó");
            string replaceOcircumflex = Regex.Replace(replaceOleft, "&#244;|&#212;", "ô");
            string replaceObar = Regex.Replace(replaceOcircumflex, "&#248;|&#216;", "ø");
            string replaceOtil = Regex.Replace(replaceObar, "&#245;|&#213;", "õ");
            string replaceOpoint = Regex.Replace(replaceOtil, "&#246;|&#214;", "ö");
            /* ú:&#250; Ú:&#218; ù:&#249; Ù:&#217; û:&#251; Û:&#219; ü:&#252; Ü:&#220; */
            string replaceUright = Regex.Replace(replaceOpoint, "&#250;|&#218;", "ú");
            string replaceUleft = Regex.Replace(replaceUright, "&#249;|&#217;", "ù");
            string replaceUcircumflex = Regex.Replace(replaceUleft, "&#251;|&#219;", "û");
            string replaceUpoint = Regex.Replace(replaceUcircumflex, "&#252;|&#220;", "ü");
            /*ÿ:&#255;*/
            string replaceY = Regex.Replace(replaceUpoint, "&#255;", "ÿ");

            return replaceY;
        }


        #endregion

        #region Lists
        /// <summary>
        /// Prefixes all items in the list w/ the prefix value.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>List with prefixes.</returns>
        public static List<string> PreFixWith(this List<string> items, string prefix)
        {
            for (int ndx = 0; ndx < items.Count; ndx++)
            {
                items[ndx] = prefix + items[ndx];
            }
            return items;
        }
        #endregion

        #region Matching
        /// <summary>
        /// Determines whether or not the string value supplied represents a "not applicable" string value by matching on na, n.a., n/a etc.
        /// </summary>
        /// <param name="val">String to check.</param>
        /// <param name="useNullOrEmptyStringAsNotApplicable">True to use null or empty string check.</param>
        /// <returns>True if the string value represents a "not applicable" string.</returns>
        public static bool IsNotApplicableValue(this string val, bool useNullOrEmptyStringAsNotApplicable = false)
        {
            bool isEmpty = string.IsNullOrEmpty(val);
            if (isEmpty && useNullOrEmptyStringAsNotApplicable) return true;
            if (isEmpty && !useNullOrEmptyStringAsNotApplicable) return false;
            val = val.Trim().ToLower();

            if (val == "na" || val == "n.a." || val == "n/a" || val == "n\\a" || val == "n.a" || val == "not applicable")
                return true;
            return false;
        }


        /// <summary>
        /// Use the Levenshtein algorithm to determine the similarity between
        /// two strings. The higher the number, the more different the two
        /// strings are.
        /// TODO: This method needs to be rewritten to handle very large strings
        /// See <a href="http://www.merriampark.com/ld.htm"></a>.
        /// See <a href="http://en.wikipedia.org/wiki/Levenshtein_distance"></a>.
        /// </summary>
        /// <param name="source">Source string to compare</param>
        /// <param name="comparison">Comparison string</param>
        /// <returns>0 if both strings are identical, otherwise a number indicating the level of difference</returns>
        public static int Levenshtein(this string source, string comparison)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "Can't parse null string");
            }
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison", "Can't parse null string");
            }

            var s = source.ToCharArray();
            var t = comparison.ToCharArray();
            var n = source.Length;
            var m = comparison.Length;
            var d = new int[n + 1, m + 1];

            // shortcut calculation for zero-length strings
            if (n == 0) { return m; }
            if (m == 0) { return n; }

            for (var i = 0; i <= n; d[i, 0] = i++) { }
            for (var j = 0; j <= m; d[0, j] = j++) { }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    var cost = t[j - 1].Equals(s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(
                        d[i - 1, j] + 1,
                        d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }


        /// <summary>
        /// Calculate the simplified soundex value for the specified string.
        /// See <a href="http://en.wikipedia.org/wiki/Soundex"></a>.
        /// See <a href="http://west-penwith.org.uk/misc/soundex.htm"></a>.
        /// </summary>
        /// <param name="source">String to calculate</param>
        /// <returns>Soundex value of string</returns>
        public static string SimplifiedSoundex(this string source)
        {
            return source.SimplifiedSoundex(4);
        }

        /// <summary>
        /// Calculate the simplified soundex value for the specified string.
        /// See <a href="http://en.wikipedia.org/wiki/Soundex"></a>.
        /// See <a href="http://west-penwith.org.uk/misc/soundex.htm"></a>.
        /// </summary>
        /// <param name="source">String to calculate</param>
        /// <param name="length">Length of soundex value (typically 4)</param>
        /// <returns>Soundex value of string</returns>
        public static string SimplifiedSoundex(this string source, int length)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (source.Length < 3)
            {
                throw new ArgumentException(
                    "Source string must be at least two characters", "source");
            }

            var t = source.ToUpper().ToCharArray();
            var buffer = new StringBuilder();

            short prev = -1;

            foreach (var c in t)
            {
                short curr = 0;
                switch (c)
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'H':
                    case 'W':
                    case 'Y':
                        curr = 0;
                        break;
                    case 'B':
                    case 'F':
                    case 'P':
                    case 'V':
                        curr = 1;
                        break;
                    case 'C':
                    case 'G':
                    case 'J':
                    case 'K':
                    case 'Q':
                    case 'S':
                    case 'X':
                    case 'Z':
                        curr = 2;
                        break;
                    case 'D':
                    case 'T':
                        curr = 3;
                        break;
                    case 'L':
                        curr = 4;
                        break;
                    case 'M':
                    case 'N':
                        curr = 5;
                        break;
                    case 'R':
                        curr = 6;
                        break;
                    default:
                        throw new ApplicationException(
                            "Invalid state in switch statement");
                }

                /* Change all consecutive duplicate digits to a single digit
                 * by not processing duplicate values. 
                 * Ignore vowels (i.e. zeros). */
                if (curr != prev)
                {
                    buffer.Append(curr);
                }

                prev = curr;
            }

            // Prefix value with first character
            buffer.Remove(0, 1).Insert(0, t.First());

            // Remove all vowels (i.e. zeros) from value
            buffer.Replace("0", "");

            // Pad soundex value with zeros until output string equals length))))
            while (buffer.Length < length) { buffer.Append('0'); }

            // Truncate values that are longer than the supplied length
            return buffer.ToString().Substring(0, length);
        }

        #endregion

        public const string CarriageReturnLineFeed = "\r\n";
        public const string Empty = "";
        public const char CarriageReturn = '\r';
        public const char LineFeed = '\n';
        public const char Tab = '\t';

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            Guard.ArgumentNotNull(format, "format");

            return string.Format(provider, format, args);
        }

        /// <summary>
        /// Determines whether the string is all white space. Empty string will return false.
        /// </summary>
        /// <param name="s">The string to test whether it is all white space.</param>
        /// <returns>
        /// 	<c>true</c> if the string is all white space; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWhiteSpace(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            if (s.Length == 0)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                    return false;
            }

            return true;
        }

        //
        // Remove all white space from a sting.
        // @param input The string to remove the white space.
        // @return The input string with no white space characters.
        //

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        /// <summary>
        /// Nulls an empty string.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns>Null if the string was null, otherwise the string unchanged.</returns>
        public static string NullEmptyString(string s)
        {
            return (string.IsNullOrEmpty(s)) ? null : s;
        }

        public static StringWriter CreateStringWriter(int capacity)
        {
            StringBuilder sb = new StringBuilder(capacity);
            StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);

            return sw;
        }

        public static int? GetLength(string value)
        {
            if (value == null)
                return null;
            else
                return value.Length;
        }

        public static string ToCharAsUnicode(char c)
        {
            char h1 = MathHelper.IntToHex((c >> 12) & '\x000f');
            char h2 = MathHelper.IntToHex((c >> 8) & '\x000f');
            char h3 = MathHelper.IntToHex((c >> 4) & '\x000f');
            char h4 = MathHelper.IntToHex(c & '\x000f');

            return new string(new[] { '\\', 'u', h1, h2, h3, h4 });
        }

        public static TSource ForgivingCaseSensitiveFind<TSource>(this IEnumerable<TSource> source, Func<TSource, string> valueSelector, string testValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (valueSelector == null)
                throw new ArgumentNullException("valueSelector");

            var caseInsensitiveResults = source.Where(s => string.Equals(valueSelector(s), testValue, StringComparison.OrdinalIgnoreCase));
            if (caseInsensitiveResults.Count() <= 1)
            {
                return caseInsensitiveResults.SingleOrDefault();
            }
            else
            {
                // multiple results returned. now filter using case sensitivity
                var caseSensitiveResults = source.Where(s => string.Equals(valueSelector(s), testValue, StringComparison.Ordinal));
                return caseSensitiveResults.SingleOrDefault();
            }
        }

        public static string ToCamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (!char.IsUpper(s[0]))
                return s;

            string camelCase = char.ToLower(s[0], CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
            if (s.Length > 1)
                camelCase += s.Substring(1);

            return camelCase;
        }

        public static bool IsInt32(this String src)
        {
            int result;
            bool ret = Int32.TryParse(src, out result);

            return ret;
        }

        public static string ParseQuote(this String src)
        {
            return src.Replace("\"", "'");
        }

        public static string Quote(this String src)
        {
            return "\"" + src + "\"";
        }

        public static string Brace(this String src)
        {
            return "[" + src + "]";
        }

        public static string Between(this String src, char c1, char c2)
        {
            return StringHelper.Between(src, c1, c2);
        }

        public static string Between(this String src, string s1, string s2)
        {
            return src.RightOf(s1).LeftOf(s2);
        }

        public static string RightOf(this String src, char c)
        {
            return StringHelper.RightOf(src, c);
        }

        public static bool BeginsWith(this String src, string s)
        {
            return src.StartsWith(s);
        }

        public static string RightOf(this String src, string s)
        {
            string ret = String.Empty;

            int idx = src.IndexOf(s);

            if (idx != -1)
            {
                ret = src.Substring(idx + s.Length);
            }

            return ret;
        }

        public static string RightOfRightmostOf(this String src, char c)
        {
            return StringHelper.RightOfRightmostOf(src, c);
        }

        public static string LeftOf(this String src, char c)
        {
            return StringHelper.LeftOf(src, c);
        }

        public static string LeftOf(this String src, string s)
        {
            string ret = s;

            int idx = src.IndexOf(s);

            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }

            return ret;
        }

        public static string LeftOfRightmostOf(this String src, char c)
        {
            return StringHelper.LeftOfRightmostOf(src, c);
        }

        public static string LeftOfRightmostOf(this String src, string s)
        {
            string ret = src;
            int idx = src.IndexOf(s);
            int idx2 = idx;

            while (idx2 != -1)
            {
                idx2 = src.IndexOf(s, idx + s.Length);

                if (idx2 != -1)
                {
                    idx = idx2;
                }
            }

            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }

            return ret;
        }

        public static string RightOfRightmostOf(this String src, string s)
        {
            string ret = src;
            int idx = src.IndexOf(s);
            int idx2 = idx;

            while (idx2 != -1)
            {
                idx2 = src.IndexOf(s, idx + s.Length);

                if (idx2 != -1)
                {
                    idx = idx2;
                }
            }

            if (idx != -1)
            {
                ret = src.Substring(idx + s.Length, src.Length - (idx + s.Length));
            }

            return ret;
        }

        public static char Rightmost(this String src)
        {
            return StringHelper.Rightmost(src);
        }

        public static string TrimLastChar(this String src)
        {
            string ret = String.Empty;
            int len = src.Length;

            if (len > 1)
            {
                ret = src.Substring(0, len - 1);
            }

            return ret;
        }

        public static bool IsBlank(this string src)
        {
            return String.IsNullOrEmpty(src) || (src.Trim() == String.Empty);
        }

        /// <summary>
        /// Returns the first occurance of any token given the list of tokens.
        /// </summary>
        public static string Contains(this string src, string[] tokens)
        {
            string ret = string.Empty;
            int firstIndex = 9999;

            // Find the index of the first index encountered.
            foreach (string token in tokens)
            {
                int idx = src.IndexOf(token);

                if ((idx != -1) && (idx < firstIndex))
                {
                    ret = token;
                    firstIndex = idx;
                }
            }

            return ret;
        }
    }
}
