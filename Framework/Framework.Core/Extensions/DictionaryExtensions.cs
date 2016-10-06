// ============================================================================
// Project: Framework
// Name/Class: DictionaryExtensions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension methods for dictionary datatype.
// ============================================================================        

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Framework.Core.Error;
using Framework.Core.Helpers;
using Framework.Core.Reflection;

namespace Framework.Core.Extensions
{
    public static class DictionaryExtensions
    {
        //
        // IDictionary --------------------------------------------------------
        //

        //
        // Check if a dictionary is not empty, return true is dictionary is 
        // null or empty, false otherwise.
        //

        public static bool NotEmpty(this IDictionary dict)
        {
            return (null != dict) && (dict.Count > 0);
        }

        //
        // IDictionary<string, string> ----------------------------------------
        //

        //
        // Add the items found in a NameValueCollection to a dictionary.
        //

        public static void Add(this IDictionary<string, string> dict, NameValueCollection coll)
        {
            if (coll.NotEmpty())
            {
                foreach (string key in coll.Keys)
                {
                    if (key.IsNotNullAndEmpty())
                    {
                        dict.Add(key, coll[key]);
                    }
                }
            }
        }

        //
        // IDictionary<string, V> ---------------------------------------------
        //

        //        
        // Take an dictionary value and a string template and replace in the string
        // the textual value of each property found. Names for properties in string
        // template have to match exactly with the names found in the object class.
        // Returns a string with the instantiated value. NOTE: the values for the
        // properties are their ToString values. Properties are referenced with
        // ${<NAME>} construct.
        //

        public static string ApplyTemplate<V>(this IDictionary<string, V> input, string template)
        {
            string output = string.Empty;

            //
            // setup an lambda function to perform the substitutions.
            //

            Func<string, string> subfunc = (property =>
            {
                string replaced = string.Empty;

                //
                // Check if key exists, if not, throw an exception.
                //

                if (input.ContainsKey(property))
                {
                    replaced = input[property].ToString();
                }
                else
                {
                    Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "ApplyTemplate cannot find property with name '{0}'", property);
                }

                return replaced;
            });

            //
            // Substitute the input string template with the property names.
            //

            output = StringHelper.Substitute(template, subfunc);

            //
            // Return output to caller.
            //

            return output;
        }

        //
        // IDictionary<K,V> ---------------------------------------------------
        //

        public static bool IsDictionaryType(Type type)
        {
            return
                (typeof(IDictionary).IsAssignableFrom(type)) ||
                (ReflectionUtils.ImplementsGenericDefinition(type, typeof(IDictionary<,>)));
        }

        //
        // Check if a dictionary is not empty, return true is 
        // dictionary is null or empty, false otherwise.
        //

        public static bool NotEmpty<K, V>(this IDictionary<K, V> dict)
        {
            return (null != dict) && (dict.Count > 0);
        }

        //
        // Add a key/value pair to a dictionary. Duplicates not allowed.
        //

        public static void Add<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            Add(dict, key, value, "Key '{0} already exists in dictionary");
        }

        public static void Add<K, V>(this IDictionary<K, V> dict, K key, V value, string message)
        {
            if (dict.ContainsKey(key))
            {
                Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, message, key);
            }

            dict.Add(key, value);
        }

        public static void Add<K, V>(this IDictionary<K, V> dict, KeyValuePair<K, V> pair)
        {
            Add(dict, pair, "Key '{0} already exists in dictionary");
        }

        public static void Add<K, V>(this IDictionary<K, V> dict, KeyValuePair<K, V> pair, string message)
        {
            Add(dict, pair.Key, pair.Value, message);
        }

        //
        // Add or update a key/value pair to a dictionary.
        //

        public static void AddOrUpdate<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }

            dict.Add(key, value);
        }

        public static void AddOrUpdate<K, V>(this IDictionary<K, V> dict, KeyValuePair<K, V> pair)
        {
            if (dict.Contains(pair))
            {
                dict.Remove(pair);
            }

            dict.Add(pair);
        }

        public static void AddNonExistent<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
        }

        public static void AddNonExistent<K, V>(this IDictionary<K, V> dict, KeyValuePair<K, V> pair)
        {
            if (!dict.Contains(pair))
            {
                dict.Add(pair);
            }
        }

        //
        // Add a list of object as key/value pairs.
        //

        public static void AddRange<K, V>(this IDictionary<K, V> dict, params object[] list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.Add(pair));
        }

        public static void AddRangeNonExistent<K, V>(this IDictionary<K, V> dict, params object[] list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddNonExistent(pair));
        }

        public static void AddRangeOrUpdate<K, V>(this IDictionary<K, V> dict, params object[] list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddOrUpdate(pair));
        }

        //
        // Add a list of object as key/value pairs.
        //

        public static void AddRange<K, V>(this IDictionary<K, V> dict, IEnumerable<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.Add(pair));
        }

        public static void AddRangeNonExistent<K, V>(this IDictionary<K, V> dict, IEnumerable<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddNonExistent(pair));
        }

        public static void AddRangeOrUpdate<K, V>(this IDictionary<K, V> dict, IEnumerable<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddOrUpdate(pair));
        }

        //
        // Add a list of object as key/value pairs.
        //

        public static void AddRange<K, V>(this IDictionary<K, V> dict, IList<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.Add(pair));
        }

        public static void AddRangeNonExistent<K, V>(this IDictionary<K, V> dict, IList<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddNonExistent(pair));
        }

        public static void AddRangeOrUpdate<K, V>(this IDictionary<K, V> dict, IList<object> list)
        {
            _ToListOfKeyValuePair<K, V>(list).Apply(pair => dict.AddOrUpdate(pair));
        }

        //
        // Add all keys from a dictionary to another dictionary.
        //

        public static void Add<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> other)
        {
            other.Apply((k, v) => { Add(dict, k, v); });
        }

        public static void AddNonExistent<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> other)
        {
            other.Apply((k, v) => { AddNonExistent(dict, k, v); });
        }

        public static void AddOrUpdate<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> other)
        {
            other.Apply((k, v) => { AddOrUpdate(dict, k, v); });
        }

        //
        // Get a required value from a dictionary.
        //

        public static V GetRequired<K, V>(this IDictionary<K, V> dict, K key)
        {
            return GetRequired(dict, key, "Key '{0}' does not exist in dictionary|");
        }

        //
        // Get a required value from a dictionary, with a custom error message.
        //

        public static V GetRequired<K, V>(this IDictionary<K, V> dict, K key, string message)
        {
            if (!dict.ContainsKey(key))
            {
                Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, message, key);
            }

            return dict[key];
        }

        //
        // Get a required value from a dictionary, applying it a conversion function.       
        //

        public static O GetRequired<K, V, O>(this IDictionary<K, V> dict, K key, Func<V, O> conv)
        {
            return GetRequired(dict, key, conv, "Key '{0}' does not exist in dictionary|");
        }

        //
        // Get a required value from a dictionary, applying it a conversion function.  
        // In case of error display a custom message.
        //

        public static O GetRequired<K, V, O>(this IDictionary<K, V> dict, K key, Func<V, O> conv, string message)
        {
            if (!dict.ContainsKey(key))
            {
                Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, message, key);
            }

            return conv(dict[key]); ;
        }

        //
        // Get an optional value from a dictionary. If key does not
        // exist, return the default value for the dictionary value type.
        //

        public static V GetOptional<K, V>(this IDictionary<K, V> dict, K key)
        {
            return GetOptional(dict, key, default(V));
        }

        //
        // Get an optional value from a dictionary. If key does not exist,
        // return the supplied user default value.
        //

        public static V GetOptional<K, V>(this IDictionary<K, V> dict, K key, V defaultVal)
        {
            return !dict.ContainsKey(key) ? defaultVal : dict[key];
        }

        //
        // Get an optional value from a diciotnary. If the key does
        // not exist return the default value. Otherwise, apply the
        // conversion function to the value.
        //

        public static O GetOptional<K, V, O>(this IDictionary<K, V> dict, K key, Func<V, O> conv, O defaultVal)
        {
            return !dict.ContainsKey(key) ? defaultVal : conv(dict[key]);
        }

        //
        // Get the value associated with the key as a int.
        //

        public static int GetInt<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToInt32(dict[key]);
        }

        //
        // Get the value associated with the key as a bool.
        //

        public static bool GetBool<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToBoolean(dict[key]);
        }

        //
        // Get the value associated with the key as a string.
        //

        public static string GetString<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToString(dict[key]);
        }

        //
        // Get the value associated with the key as a double.
        //

        public static double GetDouble<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToDouble(dict[key]);
        }

        //
        // Get the value associated with the key as a datetime.
        // 

        public static DateTime GetDateTime<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToDateTime(dict[key]);
        }

        //
        // Get the value associated with the key as a long.
        //

        public static long GetLong<K, V>(this IDictionary<K, V> dict, K key)
        {
            return Convert.ToInt64(dict[key]);
        }

        //
        // Filter a dicitonary getting all the key/value pairs that are not equal to a specifc key.
        //

        public static IDictionary<K, V> GetAllExcept<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> output, K key) where K : IEquatable<K>
        {
            dict.Apply((k, v) => { if (!k.Equals(key)) { output.Add(k, v); } });
            return output;
        }

        //
        // Return a list of objects. The list of comprised ok key, value, key, value...
        //

        public static IEnumerable<object> ToEnumObject<K, V>(this IDictionary<K, V> dict)
        {
            return dict._ToListOfObject();
        }

        //
        // Return a list of objects. The list of comprised ok key, value, key, value...
        //

        public static IEnumerable<string> ToEnumString<K, V>(this IDictionary<K, V> dict)
        {
            return dict._ToListOfObject().Map(new List<string>(), obj => { return obj.ToString(); });
        }

        //
        // Apply a handler to all elements in a dictionary.
        //

        public static void Apply<K, V>(this IDictionary<K, V> dict, Action<K, V> handler)
        {
            Apply(dict, pair => { handler(pair.Key, pair.Value); });
        }

        //
        // Apply a handler to all elements in a dictionary, adding a context object.
        //

        public static void Apply<K, V>(this IDictionary<K, V> dict, Action<K, V, object> handler, object context)
        {
            Apply(dict, (pair, ctx) => { handler(pair.Key, pair.Value, ctx); }, context);
        }

        //
        // Apply a handler to all elements in a dictionary.
        //

        public static void Apply<K, V>(this IDictionary<K, V> dict, Action<KeyValuePair<K, V>> handler)
        {
            Apply(dict, (pair, ctx) => { handler(pair); }, null);
        }

        //
        // Apply a handler to all elements in a dictionary, adding a context object.
        //

        public static void Apply<K, V>(this IDictionary<K, V> dict, Action<KeyValuePair<K, V>, object> handler, object context)
        {
            if (dict.NotEmpty())
            {
                foreach (KeyValuePair<K, V> pair in dict) { handler(pair, context); }
            }
        }

        //
        // Map a dictionary to another dictionary.
        //

        public static IDictionary<K, O> Map<K, I, O>(this IDictionary<K, I> input, IDictionary<K, O> output, Func<I, O> handler)
        {
            input.Apply((key, value) => { output.Add(key, handler(value)); });
            return output;
        }

        //
        // Map a dictionary to another dictionary.
        //

        public static IDictionary<KO, VO> Map<KI, VI, KO, VO>(this IDictionary<KI, VI> input, IDictionary<KO, VO> output, Func<KeyValuePair<KI, VI>, KeyValuePair<KO, VO>> handler)
        {
            input.Apply(pair => { output.Add(handler(pair)); });
            return output;
        }

        //
        // Build a string representation of a dictionary.
        //

        public static string UnparseToString<K, V>(this IDictionary<K, V> lst, string start, string end, string sep, string kvsep)
        {
            // 
            // Get valid string options for method.
            //

            string kvsepvalid = string.IsNullOrEmpty(kvsep) ? string.Empty : kvsep;
            string sepvalid = string.IsNullOrEmpty(sep) ? string.Empty : sep;
            string startvalid = string.IsNullOrEmpty(end) ? string.Empty : start;
            string endvalid = string.IsNullOrEmpty(end) ? string.Empty : end;

            // 
            // Unparse the dictionary.
            //

            string output = startvalid;
            int i = 0;

            foreach (K val in lst.Keys)
            {
                output += val;
                output += kvsepvalid;
                output += lst[val];

                if (i + 1 < lst.Count)
                {
                    output += sepvalid;
                }

                i++;
            }

            output += endvalid;

            // 
            // Return result.
            //

            return output;
        }

        //
        // PARSING ------------------------------------------------------------       
        //

        public static string ParseOptionalProperty_String(this IDictionary<string, string> dict, string name, string defaultValue)
        {
            return dict.ParseProperty<string>(name, false, defaultValue, Convert.ToString);
        }

        public static string ParseRequiredProperty_String(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<string>(name, true, default(string), Convert.ToString);
        }

        public static string ParseOptionalProperty_String<T>(this IDictionary<string, string> dict, string name, string defaultValue, Func<string, string> parseDelegate)
        {
            return dict.ParseProperty<string>(name, false, defaultValue, parseDelegate);
        }

        public static string ParseRequiredProperty_String<T>(this IDictionary<string, string> dict, string name, Func<string, string> parseDelegate)
        {
            return dict.ParseProperty<string>(name, true, default(string), parseDelegate);
        }

        public static T ParseOptionalPropertySet<T>(this IDictionary<string, string> dict, string name, T defaultValue, params object[] set)
        {
            return dict.ParsePropertySet<T>(name, false, defaultValue, true, set);
        }

        public static T ParseRequiredPropertySet<T>(this IDictionary<string, string> dict, string name, params object[] set)
        {
            return dict.ParsePropertySet<T>(name, true, default(T), true, set);
        }

        public static double ParseOptionalProperty_Double<T>(this IDictionary<string, string> dict, string name, double defaultValue)
        {
            return dict.ParseProperty<double>(name, false, defaultValue, Convert.ToDouble);
        }

        public static double ParseRequiredProperty_Double<T>(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<double>(name, true, default(double), Convert.ToDouble);
        }

        public static bool ParseOptionalProperty_YesNo<T>(this IDictionary<string, string> dict, string name, bool defaultValue)
        {
            return dict.ParseProperty<bool>(name, false, defaultValue, Convert.ToBoolean);
        }

        public static bool ParseRequiredProperty_YesNo<T>(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<bool>(name, true, default(bool), Convert.ToBoolean);
        }

        public static bool ParseOptionalProperty_Bool<T>(this IDictionary<string, string> dict, string name, bool defaultValue)
        {
            return dict.ParseProperty<bool>(name, false, defaultValue, Convert.ToBoolean);
        }

        public static bool ParseRequiredProperty_Bool<T>(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<bool>(name, true, default(bool), Convert.ToBoolean);
        }

        public static int ParseOptionalProperty_Int<T>(this IDictionary<string, string> dict, string name, int defaultValue)
        {
            return dict.ParseProperty<int>(name, false, defaultValue, Convert.ToInt32);
        }

        public static int ParseRequiredProperty_Int<T>(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<int>(name, true, default(int), Convert.ToInt32);
        }

        public static DateTime ParseOptionalProperty_DateTime<T>(this IDictionary<string, string> dict, string name, DateTime defaultValue)
        {
            return dict.ParseProperty<DateTime>(name, false, defaultValue, Convert.ToDateTime);
        }

        public static DateTime ParseRequiredProperty_DateTime(this IDictionary<string, string> dict, string name)
        {
            return dict.ParseProperty<DateTime>(name, true, default(DateTime), Convert.ToDateTime);
        }

        public static R ParseProperty<R>(this IDictionary<string, string> dict, string name, bool required, R defaultValue, Func<string, R> parseDelegate)
        {
            R output = defaultValue;

            // 
            // Check if attribute exists
            //

            if (dict.ContainsKey(name))
            {
                string strValue = dict[name];
                if (string.IsNullOrEmpty(strValue) && required)
                {
                    Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "Property '{0}' is required, but has an empty value!", name);
                }

                output = parseDelegate(strValue);
            }
            else
            {
                // 
                // Attribute does not exist, is it required, if so, we have an error
                //

                if (required)
                {
                    Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "Property '{0}' is required, but was not found!", name);
                }
            }

            return output;
        }

        public static R ParsePropertySet<R>(this IDictionary<string, string> dict, string name, bool required, R defaultValue, bool insensitive, params object[] set)
        {
            R retValue = defaultValue;

            // 
            // Check if attribute exists.
            //

            if (dict.ContainsKey(name))
            {
                string value = dict[name];
                retValue = value.ParseValue_Set<R>(required, defaultValue, insensitive, set);
            }
            else
            {
                // 
                // Attribute does not exist, is it required, if so, we have an error.
                //

                if (required)
                {
                    Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "Property '{0}' is required, but was not found!", name);
                }
            }

            return retValue;
        }

        //
        // HELPERS
        //

        private static IEnumerable<KeyValuePair<K, V>> _ToListOfKeyValuePair<K, V>(this IEnumerable<object> list)
        {
            IList<KeyValuePair<K, V>> output = new List<KeyValuePair<K, V>>();

            K key = default(K);

            EnumerableExtensions.Apply(list, (value, index) =>
            {
                if (index.IsEven())
                {
                    key = (K)value;
                }
                else
                {
                    output.Add(new KeyValuePair<K, V>(key, (V)value));
                }
            });

            return output;
        }

        private static IEnumerable<object> _ToListOfObject<K, V>(this IEnumerable<KeyValuePair<K, V>> list)
        {
            IList<object> output = new List<object>();
            EnumerableExtensions.Apply(list, (pair, index) => { output.AddRange(pair.Key, pair.Value); });
            return output;
        }
    }
}
