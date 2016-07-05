// ============================================================================
// Project: Framework
// Name/Class: ListExtensions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension methods for IList datatype.
// ============================================================================                    

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Reflection;

namespace Framework.Core.Extensions
{
    public static class ListExtensions
    {
        //
        // Check if list is not empty or null.
        //

        public static bool NotEmpty<T>(this IList<T> list)
        {
            return ((null != list) && (list.Count > 0));
        }

        //
        // Create a generic list of a specific type.
        //

        public static IList Create(Type listType)
        {
            return (IList)ReflectionUtils.CreateGeneric(typeof(List<>), listType);
        }

        //
        // Add a range of items of same type to IList.
        //

        public static void AddRange<T>(this IList<T> list, params T[] items)
        {
            items.Apply(list.Add);
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            items.Apply(list.Add);
        }

        public static void AddRange<T>(this IList<T> list, IList<T> items)
        {
            items.Apply(list.Add);
        }

        //
        // Add and item or items to an existing list if those items do not already exist.
        //

        public static bool AddDistinct<T>(this IList<T> list, T value, IEqualityComparer<T> handler = null)
        {
            IEqualityComparer<T> comparer = (null == handler) ? handler : EqualityComparer<T>.Default;
            bool output = false;

            if (!list.Contains(value, comparer))
            {
                list.Add(value);
                output = true;
            }

            return output;
        }

        public static bool AddRangeDistinct<T>(this IList<T> list, IEqualityComparer<T> comparer = null, params T[] items)
        {
            return AddRangeDistinct(list, items.ToList(), comparer);
        }

        public static bool AddRangeDistinct<T>(this IList<T> list, IEnumerable<T> items, IEqualityComparer<T> comparer = null)
        {
            bool output = false;
            items.Apply(value => output |= AddDistinct(list, value, comparer));
            return output;
        }

        public static bool AddRangeDistinct<T>(this IList<T> list, IList<T> items, IEqualityComparer<T> comparer = null)
        {
            return AddRangeDistinct(list, items, comparer);
        }

        //
        // List catamorphism pattern.
        //

        public static R Catamorphism<R, T>(this IList<T> list, Func<R> emptyGene, Func<T, R, R> tailDelegate)
        {
            R result = default(R);

            if (null == list || list.Count == 0)
            {
                result = emptyGene();
            }
            else
            {
                result = tailDelegate(list.First<T>(), Catamorphism(list.Skip<T>(1).ToList<T>(), emptyGene, tailDelegate));
            }

            return result;
        }

        public static R Catamorphism<R, T>(this IList<T> list, R emptyValue, Func<T, R, R> tailDelegate)
        {
            R result = default(R);

            if (null == list || list.Count == 0)
            {
                result = emptyValue;
            }
            else
            {
                result = tailDelegate(list.First<T>(), Catamorphism(list.Skip<T>(1).ToList<T>(), emptyValue, tailDelegate));
            }

            return result;
        }

        //
        // Apply a specific action to all items in a list.
        //

        public static void Apply<T>(this IList<T> list, Action<T> handler)
        {
            if (null != handler) { Apply(list, (value, index, ctx) => { handler(value); }, null); }
        }

        public static void Apply<T>(this IList<T> list, Action<T, int> handler)
        {
            if (null != handler) { Apply(list, (value, index, ctx) => { handler(value, index); }, null); }
        }

        public static void Apply<T>(this IList<T> list, Action<T, int, object> handler, object context)
        {
            if (list.NotEmpty() && null != handler) { for (int i = 0; i < list.Count; i++) { handler(list[i], i, context); } }
        }

        //
        // Map lists into other lists supplying the transformation function.
        //

        public static IList<O> Map<I, O>(this IList<I> list, IList<O> output, Func<I, O> handler)
        {
            return Map(list, output, (value, index, ctx) => { return handler(value); }, null);
        }

        public static IList<O> Map<I, O>(this IList<I> list, IList<O> output, Func<I, int, O> handler)
        {
            return Map(list, output, (value, index, ctx) => { return handler(value, index); }, null);
        }

        public static IList<O> Map<I, O>(this IList<I> list, IList<O> output, Func<I, int, object, O> handler, object context)
        {
            Apply(list, (value, index, ctx) => { output.Add(handler(value, index, ctx)); }, context);
            return output;
        }

        //
        // Shuffles the contents of a list
        //

        public static void Shuffle<T>(this IList<T> list, int numberOfTimesToShuffle = 5)
        {
            // 
            // make a new list of the wanted type
            //

            IList<T> newList = new List<T>();

            //
            // for each time we want to shuffle
            //

            for (int i = 0; i < numberOfTimesToShuffle; i++)
            {
                //
                // while there are still items in our list
                //

                while (list.Count > 0)
                {
                    //
                    // get a random number within the list
                    //

                    int index = _rnd.Next(list.Count);

                    //
                    // add the item at that position to the new list
                    //

                    newList.Add(list[index]);

                    //
                    // and remove it from the old list
                    //

                    list.RemoveAt(index);
                }

                //
                // then copy all the items back in the old list again
                //

                list.AddRange(newList);

                //
                // and clear the new list
                // to make ready for next shuffling
                //

                newList.Clear();
            }
        }

        //
        // Random value object getter.
        //

        private static Random _rnd = new Random();
    }
}
