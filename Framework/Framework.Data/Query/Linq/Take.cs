// ============================================================================
// Project:
// Name/Class: 
// Author: Joao Carreiro (jao.carreiro@cybermap.pt)
// Create date: 26/Nov/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using System.Linq;

namespace Framework.Data.Query.Linq
{
    public static class Take
    {
        public static IQueryable<TItem> Optional<TItem>(this IQueryable<TItem> query, Nullable<int> n) where TItem : class
        {
            IQueryable<TItem> output = query;

            if (n.HasValue && n.Value > 0)
            {
                output = query.Take(n.Value);
            }

            return output;
        }

        public static IQueryable<TItem> OptionalPlusOne<TItem>(this IQueryable<TItem> query, Nullable<int> n) where TItem : class
        {
            IQueryable<TItem> output = query;

            if (n.HasValue && n.Value > 0)
            {
                output = query.Take(n.Value + 1);
            }

            return output;
        }

        public static IQueryable<TItem> Between<TItem>(this IQueryable<TItem> query, int startIndex, int endIndex) where TItem : class
        {
            return query.Skip(startIndex).Take(endIndex - startIndex);
        }

        public static IQueryable<TItem> FromIndex<TItem>(this IQueryable<TItem> query, int startIndex, int N) where TItem : class
        {
            return query.Skip(startIndex).Optional(N);
        }

        public static IQueryable<TItem> FromIndexPlusOne<TItem>(this IQueryable<TItem> query, int startIndex, int N) where TItem : class
        {
            return query.FromIndex(startIndex, N * N == 0 ? 0 : N + 1);
        }

        public static IQueryable<TItem> DropLast<TItem>(this IQueryable<TItem> query)
        {
            return query.Take(query.Count() - 1);
        }
    }
}
