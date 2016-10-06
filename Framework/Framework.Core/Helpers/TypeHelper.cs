// ============================================================================
// Project: Framework
// Name/Class: TypeHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper functions for types.
// ============================================================================

using Framework.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework.Core.Helpers
{
    public class TypeHelper
    {
        //
        // STATIC CONSTRUCTOR
        //

        static TypeHelper()
        {
            //
            // Build the set of numeric types.
            //

            _NumericTypes = new Dictionary<string, bool>();
            _NumericTypes[typeof(int).Name] = true;
            _NumericTypes[typeof(long).Name] = true;
            _NumericTypes[typeof(float).Name] = true;
            _NumericTypes[typeof(double).Name] = true;
            _NumericTypes[typeof(decimal).Name] = true;
            _NumericTypes[typeof(sbyte).Name] = true;
            _NumericTypes[typeof(Int16).Name] = true;
            _NumericTypes[typeof(Int32).Name] = true;
            _NumericTypes[typeof(Int64).Name] = true;
            _NumericTypes[typeof(Double).Name] = true;
            _NumericTypes[typeof(Decimal).Name] = true;

            //
            // Build the set of basic types.
            //

            _BasicTypes = new Dictionary<string, bool>();
            _BasicTypes[typeof(int).Name] = true;
            _BasicTypes[typeof(long).Name] = true;
            _BasicTypes[typeof(float).Name] = true;
            _BasicTypes[typeof(double).Name] = true;
            _BasicTypes[typeof(decimal).Name] = true;
            _BasicTypes[typeof(sbyte).Name] = true;
            _BasicTypes[typeof(Int16).Name] = true;
            _BasicTypes[typeof(Int32).Name] = true;
            _BasicTypes[typeof(Int64).Name] = true;
            _BasicTypes[typeof(Double).Name] = true;
            _BasicTypes[typeof(Decimal).Name] = true;
            _BasicTypes[typeof(bool).Name] = true;
            _BasicTypes[typeof(DateTime).Name] = true;
            _BasicTypes[typeof(string).Name] = true;
        }

        //
        // Determines whether the supplied object is of a numeric type.
        //

        public static bool IsNumeric(object val)
        {
            return _NumericTypes.ContainsKey(val.GetType().Name);
        }

        //
        // Determines whether objects of the supplied type are numeric.
        //

        public static bool IsNumeric(Type type)
        {
            return _NumericTypes.ContainsKey(type.Name);
        }

        //
        // Determines whether the type represents a basic type.
        //

        public static bool IsBasicType(Type type)
        {
            return _BasicTypes.ContainsKey(type.Name);
        }

        //
        // PARSING TYPES
        //

        public static Type ParseType(string input)
        {
            Type type = default(Type);
            string trimmed = input.TrimStart();
            string tail = string.Empty;
            string segment = string.Empty;

            if (trimmed.StartsWith("_|_"))
            {
                type = null;
            }
            else
            {
                // must be an identifier, parse it
                string identifier = string.Empty;
                _ParseIdentifier(input, out identifier, out tail);

                switch (identifier.ToLower())
                {
                    case "bool":
                        type = typeof(bool);
                        break;
                    case "char":
                        type = typeof(char);
                        break;
                    case "date":
                        type = typeof(DateTime);
                        break;
                    case "float":
                        type = typeof(float);
                        break;
                    case "double":
                        type = typeof(double);
                        break;
                    case "int":
                        type = typeof(int);
                        break;
                    case "string":
                        type = typeof(string);
                        break;
                    default:
                        {
                            throw new Exception(String.Format("{0} invalid type identifier '{1}' in type definition", Config.Lib.DEFAULT_ERROR_MSG_PREFIX, identifier));
                        }
                }
            }

            if (tail.IsNotNullAndEmpty())
            {
                throw new Exception(String.Format("{0} invalid type definition, invalid characters at the end '{1}'", Config.Lib.DEFAULT_ERROR_MSG_PREFIX, tail));
            }

            return type;
        }

        private static void _ParseIdentifier(string input, out string identifier, out string tail)
        {
            int sindex = 0;
            identifier = string.Empty;

            while ((sindex < input.Length) && (_IsIdentifierChar(input[sindex])))
            {
                identifier += input[sindex++];
            }

            tail = input.Substring(sindex);
        }

        private static bool _IsIdentifierChar(char s)
        {
            return Char.IsLetterOrDigit(s) || s == '.' || s == '_' || s == '-';
        }

        //
        // PARSING VALUES
        //

        public static object ParseValue(Type type, string input)
        {
            return ParseValue(type, input, CultureInfo.CurrentCulture);
        }

        public static object ParseValue(Type type, string input, CultureInfo cult)
        {
            object value = input;

            if (null == type)
            {
                input = null;
            }
            else if (type == typeof(bool))
            {
                value = input.ParseRequiredValue_Bool();
            }
            else if (type == typeof(char))
            {
                value = input;
            }
            else if (type == typeof(DateTime))
            {
                value = input.ParseRequiredValue_DateTime(cult);
            }
            else if (type == typeof(float) || type == typeof(double))
            {
                value = input.ParseRequiredValue_Double(cult);
            }
            else if (type == typeof(string))
            {
                value = input;
            }
            else
            {
                value = input;
            }

            return value;
        }

        //
        // CONVERT OBJECT -> OBJECT
        //

        public static object ConvertObj<T>(object input)
        {
            return ConvertObj<T>(input, CultureInfo.CurrentCulture);
        }

        public static object ConvertObj<T>(object input, CultureInfo cult)
        {
            if (input == null) return default(T);

            if (typeof(T) == typeof(int))
                return System.Convert.ToInt32(input, cult.NumberFormat);
            else if (typeof(T) == typeof(long))
                return System.Convert.ToInt64(input, cult.NumberFormat);
            else if (typeof(T) == typeof(string))
                return System.Convert.ToString(input, cult.NumberFormat);
            else if (typeof(T) == typeof(bool))
                return System.Convert.ToBoolean(input, cult.NumberFormat);
            else if (typeof(T) == typeof(double))
                return System.Convert.ToDouble(input, cult.NumberFormat);
            else if (typeof(T) == typeof(DateTime))
                return System.Convert.ToDateTime(input, cult.NumberFormat);

            return default(T);
        }

        public static object ConvertTo(Type type, object input)
        {
            return ConvertTo(type, input, CultureInfo.CurrentCulture);
        }

        public static object ConvertTo(Type type, object input, CultureInfo cult)
        {
            object result = null;
            if (input == null || input == DBNull.Value) return null;

            if (type == typeof(int))
                result = System.Convert.ToInt32(input, cult.NumberFormat);
            else if (type == typeof(long))
                result = System.Convert.ToInt64(input, cult.NumberFormat);
            else if (type == typeof(string))
                result = System.Convert.ToString(input, cult.NumberFormat);
            else if (type == typeof(bool))
                result = System.Convert.ToBoolean(input, cult.NumberFormat);
            else if (type == typeof(double))
                result = System.Convert.ToDouble(input, cult.NumberFormat);
            else if (type == typeof(DateTime))
                result = System.Convert.ToDateTime(input, cult.NumberFormat);

            return result;
        }

        //
        // CONVERT OBJECT -> T (Generic)
        //

        public static T ConvertTo<T>(object input)
        {
            return ConvertTo<T>(input, CultureInfo.CurrentCulture);
        }

        public static T ConvertTo<T>(object input, CultureInfo cult)
        {
            object result = default(T);
            if (input == null || input == DBNull.Value) return (T)result;

            if (typeof(T) == typeof(int))
                result = System.Convert.ToInt32(input, cult.NumberFormat);
            else if (typeof(T) == typeof(long))
                result = System.Convert.ToInt64(input, cult.NumberFormat);
            else if (typeof(T) == typeof(string))
                result = System.Convert.ToString(input, cult.NumberFormat);
            else if (typeof(T) == typeof(bool))
                result = System.Convert.ToBoolean(input, cult.NumberFormat);
            else if (typeof(T) == typeof(double))
                result = System.Convert.ToDouble(input, cult.NumberFormat);
            else if (typeof(T) == typeof(DateTime))
                result = System.Convert.ToDateTime(input, cult.NumberFormat);

            return (T)result;
        }

        //
        // CHECK IF CONVERSION IS POSSIBLE
        //

        public static bool CanConvertTo<T>(string val)
        {
            return CanConvertTo(typeof(T), val);
        }

        public static bool CanConvertTo<T>(string val, CultureInfo cult)
        {
            return CanConvertTo(typeof(T), val, cult);
        }

        public static bool CanConvertTo(Type type, string val)
        {
            return CanConvertTo(type, val, CultureInfo.CurrentCulture);
        }

        public static bool CanConvertTo(Type type, string val, CultureInfo cult)
        {
            try
            {
                if (type == typeof(int))
                {
                    int result = 0;
                    if (int.TryParse(val, NumberStyles.Integer | NumberStyles.AllowThousands, cult.NumberFormat, out result)) return true;

                    return false;
                }
                else if (type == typeof(string))
                {
                    return true;
                }
                else if (type == typeof(double))
                {
                    double d = 0;
                    if (double.TryParse(val, NumberStyles.Any | NumberStyles.AllowThousands, cult.NumberFormat, out d)) return true;

                    return false;
                }
                else if (type == typeof(long))
                {
                    long l = 0;
                    if (long.TryParse(val, NumberStyles.Any | NumberStyles.AllowThousands, cult.NumberFormat, out l)) return true;

                    return false;
                }
                else if (type == typeof(float))
                {
                    float f = 0;
                    if (float.TryParse(val, NumberStyles.Any | NumberStyles.AllowThousands, cult.NumberFormat, out f)) return true;

                    return false;
                }
                else if (type == typeof(bool))
                {
                    bool b = false;
                    if (bool.TryParse(val, out b)) return true;

                    return false;
                }
                else if (type == typeof(DateTime))
                {
                    DateTime d = DateTime.MinValue;
                    if (DateTime.TryParse(val, cult.NumberFormat, DateTimeStyles.None, out d)) return true;

                    return false;
                }
                else if (type.BaseType == typeof(Enum))
                {
                    Enum.Parse(type, val, true);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //
        // PRIVATE STATIC FIELDS
        //

        private static readonly IDictionary<string, bool> _NumericTypes;
        private static readonly IDictionary<string, bool> _BasicTypes;
    }
}
