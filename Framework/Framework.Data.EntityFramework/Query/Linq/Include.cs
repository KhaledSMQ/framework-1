// ============================================================================
// Project:
// Name/Class: 
// Author: Joao Carreiro (jao.carreiro@cybermap.pt)
// Create date: 26/Nov/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Data.EntityFramework.Query.Linq
{
    public static class Include
    {
        public static TItem MultipleArray<TItem, TID>(this IQueryable<TItem> query, TID id, string[] includes) where TItem : class, IID<TID>
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.SingleOrDefault(item => item.Equals(id));
        }

        public static IQueryable<TItem> Multiple<TItem>(this IQueryable<TItem> query, string[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public static IQueryable<TItem> MultipleArray<TItem>(this IQueryable<TItem> query, Expression<Func<TItem, object>>[] includes) where TItem : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<TItem> Multiple<TItem>(this IQueryable<TItem> query, params Expression<Func<TItem, object>>[] includes) where TItem : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
