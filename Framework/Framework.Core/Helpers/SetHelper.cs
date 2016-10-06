// ============================================================================
// Project: Framework
// Name/Class: SetHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper class for sets.
// ============================================================================

using Framework.Core.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Core.Helpers
{
    public class SetHelper<T>
    {
        //
        // Gets all the unique elements from both sets.
        // Whats in first OR second.
        //

        public static ISet<T> Union(ISet<T> first, ISet<T> second)
        {
            ISet<T> union = new DictSet<T>();

            //
            // Add first set.
            //

            System.Collections.Generic.IEnumerator<T> items = first.GetEnumerator();
            while (items.MoveNext())
            {
                if (!union.Contains(items.Current))
                {
                    union.Add(items.Current);
                }
            }

            //
            // Add second set.
            //

            items = second.GetEnumerator();
            while (items.MoveNext())
            {
                if (!union.Contains(items.Current))
                {
                    union.Add(items.Current);
                }
            }

            return union;
        }

        //
        // Finds the intersection of the elements in first and second.
        // Whats in both first AND second.
        //

        public static ISet<T> Intersect(ISet<T> first, ISet<T> second)
        {
            ISet<T> intersect = new DictSet<T>();

            // 
            // Determine which ones to check.
            //

            ISet<T> setToIterate = first;
            ISet<T> setToCheck = second;

            if (second.Count > first.Count)
            {
                setToIterate = second;
                setToCheck = first;
            }

            System.Collections.Generic.IEnumerator<T> items = setToIterate.GetEnumerator();
            while (items.MoveNext())
            {
                if (setToCheck.Contains(items.Current))
                {
                    intersect.Add(items.Current);
                }
            }

            return intersect;
        }

        //
        // Exclusives the or.
        //

        public static ISet<T> ExclusiveOr(ISet<T> first, ISet<T> second)
        {
            ISet<T> union = new DictSet<T>();

            System.Collections.Generic.IEnumerator<T> items = first.GetEnumerator();
            while (items.MoveNext())
            {
                if (!second.Contains(items.Current))
                {
                    union.Add(items.Current);
                }
            }

            items = second.GetEnumerator();
            while (items.MoveNext())
            {
                if (!first.Contains(items.Current))
                {
                    union.Add(items.Current);
                }
            }

            return union;
        }

        //
        // Minuses the specified other.
        //

        public static ISet<T> Minus(ISet<T> first, ISet<T> second)
        {
            ISet<T> minus = new DictSet<T>();

            System.Collections.Generic.IEnumerator<T> items = first.GetEnumerator();
            while (items.MoveNext())
            {
                if (!second.Contains(items.Current))
                {
                    minus.Add(items.Current);
                }
            }

            return minus;
        }
    }
}
