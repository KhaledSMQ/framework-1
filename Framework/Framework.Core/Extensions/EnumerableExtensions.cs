// ============================================================================
// Project: Framework
// Name/Class: EnumerableExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension methods for enumerations.
// ============================================================================                    

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core.Helpers;

namespace Framework.Core.Extensions
{
    public static class EnumerableExtensions
    {
        //
        // Check if list is not empty or not null.
        //

        public static bool NotEmpty<T>(this IEnumerable<T> list)
        {
            return ((null != list) && (list.Count() > 0));
        }

        //
        // Check if the enumeration has any null object instances.
        //

        public static bool HasAnyNulls<T>(this IEnumerable<T> items)
        {
            return items.IsTrueForAny<T>(t => t == null);
        }

        //
        // Check if any of the items in the collection satisfy a condition.
        //

        public static bool IsTrueForAny<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items.NotEmpty() && null != predicate)
            {
                foreach (T item in items)
                {
                    if (predicate(item)) { return true; }
                }
            }

            return false;
        }

        //
        // Cast an enumerable to another enumerable validating the supplied return type.
        //

        public static IEnumerable<T> CastValid<T>(this IEnumerable enumerable)
        {
            Guard.ArgumentNotNull(enumerable, "enumerable");
            return enumerable.Cast<object>().Where(o => o is T).Cast<T>();
        }

        //
        // Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer.
        //

        public static int IndexOf<T>(this IEnumerable<T> list, T value, IEqualityComparer<T> handler)
        {
            IEqualityComparer<T> comparer = (null == handler) ? handler : EqualityComparer<T>.Default;

            int index = -1;

            foreach (T item in list)
            {
                index++;
                if (comparer.Equals(item, value))
                {
                    break;
                }
            }

            return index;
        }

        //
        // Returns the index of the first occurrence in a sequence by using a specified predicate handler.
        //

        public static int IndexOf<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            int index = -1;

            foreach (T item in list)
            {
                index++;
                if (predicate(item))
                {
                    break;
                }
            }

            return index;
        }

        // 
        // This is here because LINQ Bridge doesn't support Contains with IEqualityComparer<T>
        //

        public static bool Contains<T>(this IEnumerable<T> list, T value, IEqualityComparer<T> handler)
        {
            IEqualityComparer<T> comparer = (null == handler) ? handler : EqualityComparer<T>.Default;

            bool found = false;

            foreach (T item in list)
            {
                if (handler.Equals(item, value))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        //
        // Apply a specific action to all items in a enumerable.
        //

        public static void Apply<T>(this IEnumerable list, Action<T> handler)
        {
            if (null != handler && null != list) { foreach (T item in list) { handler(item); } }
        }

        //
        // Apply a specific action to all items in a list.
        //

        public static void Apply<T>(this IEnumerable<T> list, Action<T> handler)
        {
            if (null != handler) { Apply(list, (value, ctx) => { handler(value); }, null); }
        }

        //
        // Apply a specific action to all items in a list.
        // Keep track of the index in each item.
        //

        public static void Apply<T>(this IEnumerable<T> list, Action<T, int> handler)
        {
            if (null != handler) { Apply(list, (value, index, ctx) => { handler(value, index); }, null); }
        }

        //
        // Apply a specific action to all items in a list, spread a context object.
        //

        public static void Apply<T>(this IEnumerable<T> list, Action<T, object> handler, object context)
        {
            if (list.NotEmpty() && null != handler) { foreach (T item in list) { handler(item, context); } }
        }

        //
        // Apply a specific action to all items in a list.
        // Keep track of the index in each item.
        // Spread a context object.
        //

        public static void Apply<T>(this IEnumerable<T> list, Action<T, int, object> handler, object context)
        {
            if (list.NotEmpty() && null != handler)
            {
                int index = 0;

                foreach (T item in list)
                {
                    handler(item, index, context);
                    index++;
                }
            }
        }

        public static IList<O> Map<I, O>(this IEnumerable list, IList<O> output, Func<I, O> handler)
        {
            list.Apply<I>(item => output.Add(handler(item)));
            return output;
        }

        //
        // Map a enumeration to a list instance, applying to each item in 
        // the enumeration a particular function.
        //

        public static IList<O> Map<I, O>(this IEnumerable<I> list, IList<O> output, Func<I, O> handler)
        {
            return Map(list, output, (value, ctx) => { return handler(value); }, null);
        }

        //
        // Map a enumeration to a list instance, applying to each item in 
        // the enumeration a particular function. Spread a context.
        //

        public static IList<O> Map<I, O>(this IEnumerable<I> list, IList<O> output, Func<I, object, O> handler, object context)
        {
            Apply(list, (value, ctx) => output.Add(handler(value, ctx)), context);
            return output;
        }

        //
        // Joins the specified items.
        //

        public static string Join<T>(this IList<T> items, string delimeter)
        {
            if (items == null || items.Count == 0)
                return string.Empty;

            if (items.Count == 1)
                return items[0].ToString();

            StringBuilder buffer = new StringBuilder();
            buffer.Append(items[0].ToString());

            for (int ndx = 1; ndx < items.Count; ndx++)
            {
                string append = items[ndx].ToString();
                buffer.Append(delimeter + append);
            }

            return buffer.ToString();
        }

        //
        // Joins the specified items.
        // @param items array of items
        // @param delimiter the string to use as a delimeter
        // @return the string of the joined items string representation.
        //

        public static string Join<T>(this T[] items, string delimeter)
        {
            return Join<T>(items, delimeter, 0);
        }

        //
        // Joins the specified items.
        // @param items array of items
        // @param delimiter the string to use as a delimeter
        // @return the string of the joined items string representation.
        //

        public static string Join<T>(this T[] items, string delimeter, int startIndex)
        {
            return Join<T>(items, delimeter, startIndex, items.Length);
        }

        //
        // Joins the specified items.
        // @param items array of items
        // @param delimiter the string to use as a delimeter
        // @return the string of the joined items string representation.
        //

        public static string Join<T>(this T[] items, string delimeter, int startIndex, int endIndex)
        {
            if (items == null || items.Length == 0)
            {
                return string.Empty;
            }

            if (startIndex >= items.Length)
            {
                return string.Empty;
            }

            if (items.Length == 1)
            {
                return items[0].ToString();
            }

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= items.Length)
            {
                endIndex = items.Length;
            }

            StringBuilder buffer = new StringBuilder();
            buffer.Append(items[startIndex].ToString());

            for (int ndx = startIndex + 1; ndx < endIndex; ndx++)
            {
                string append = items[ndx].ToString();
                buffer.Append(delimeter + append);
            }

            return buffer.ToString();
        }

        //
        // Join values using a delimeter.
        //

        public static string JoinDelimited<T>(this IList<T> items, string delimeter, Func<T, string> appender)
        {
            if (items == null || items.Count == 0)
            {
                return string.Empty;
            }

            if (items.Count == 1)
            {
                return appender(items[0]);
            }

            StringBuilder buffer = new StringBuilder();
            string val = appender == null ? items[0].ToString() : appender(items[0]);
            buffer.Append(val);

            for (int ndx = 1; ndx < items.Count; ndx++)
            {
                T item = items[ndx];
                val = appender == null ? item.ToString() : appender(item);
                buffer.Append(delimeter + val);
            }

            return buffer.ToString();
        }

        //
        // Join values using a delimeter.
        //

        public static string JoinDelimitedWithNewLine<T>(this IList<T> items, string delimeter, int newLineAfterCount, string newLineText, Func<T, string> appender)
        {
            if (items == null || items.Count == 0)
            {
                return string.Empty;
            }

            if (items.Count == 1)
            {
                return appender(items[0]);
            }

            StringBuilder buffer = new StringBuilder();
            buffer.Append(appender(items[0]));

            for (int ndx = 1; ndx < items.Count; ndx++)
            {
                T item = items[ndx];
                string append = appender(item);

                if (ndx % newLineAfterCount == 0)
                {
                    buffer.Append(newLineText);
                }

                buffer.Append(delimeter + append);
            }

            return buffer.ToString();
        }

        //
        // Unparse a enumerable to a string, applying the ToString method of the objects
        //

        public static string UnparseToString<T>(this IEnumerable<T> list)
        {
            return list.UnparseToString<T>("[", "]", ",");
        }

        //
        // Unparse a enumerable to a string, applying the ToString method of the objects
        //

        public static string UnparseToString<T>(this IEnumerable<T> list, string sep)
        {
            return list.UnparseToString<T>(string.Empty, string.Empty, sep);
        }

        //
        // Unparse a enumerable to a string, applying the ToString method of the objects
        //

        public static string UnparseToString<T>(this IEnumerable<T> list, string start, string end, string sep)
        {
            int i = 0;
            string output = start;

            foreach (object val in list)
            {
                output += val.ToString();

                if (!string.IsNullOrEmpty(sep) && (i + 1 < list.Count<T>()))
                {
                    output += sep;
                }

                i++;
            }

            output += end;
            return output;
        }

        //
        // Unparse a enumerable to a string, applying a generic unparser method of the objects.
        //

        public static string UnparseToString<T>(this IEnumerable<T> list, string sep, Func<T, string> unparser)
        {
            return list.UnparseToString<T>(string.Empty, string.Empty, sep, unparser);
        }

        //
        // Unparse a enumerable to a string, applying a generic unparser method of the objects.
        //

        public static string UnparseToString<T>(this IEnumerable<T> list, string start, string end, string sep, Func<T, string> unparser)
        {
            int i = 0;
            string output = start;

            foreach (T val in list)
            {
                output += unparser(val);

                if (!string.IsNullOrEmpty(sep) && (i + 1 < list.Count<T>()))
                {
                    output += sep;
                }

                i++;
            }

            output += end;
            return output;
        }

        //
        // Clone a enumeration to another enumeration, applying to each item in 
        // the enumeration the cloning method.
        //

        public static IList<T> Clone<T>(this IEnumerable<T> list) where T : ICloneable
        {
            return Map(list, new List<T>(), value => { return (T)value.Clone(); });
        }

        //
        // Converts a list of items to a dictionary with the items.
        //

        public static IDictionary<T, T> ToDictionary<T>(this IList<T> items)
        {
            IDictionary<T, T> dict = new Dictionary<T, T>();

            foreach (T item in items)
            {
                dict[item] = item;
            }

            return dict;
        }
    }
}
