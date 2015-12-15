// ============================================================================
// Project: Framework
// Name/Class: Where
// Author: Joao Carreiro (jao.carreiro@cybermap.pt)
// Create date: 26/Nov/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Data.Query.Linq
{
    public static class Where
    {
        public static IQueryable<TItem> MultipleWhere<TItem>(this IQueryable<TItem> query, IEnumerable<Expression<Func<TItem, bool>>> wheres) where TItem : class
        {
            IQueryable<TItem> output = query;

            if (null != wheres && wheres.Count() > 0)
            {
                output = query.MultipleWhere<TItem>(wheres.ToArray());
            }

            return output;
        }

        public static IQueryable<TItem> MultipleWhere<TItem>(this IQueryable<TItem> query, params Expression<Func<TItem, bool>>[] wheres) where TItem : class
        {
            IQueryable<TItem> output = query;

            if (null != wheres && wheres.Length > 0)
            {
                output = wheres.Aggregate(query, (current, include) => current.Where(include));
            }

            return output;
        }
    }
}
