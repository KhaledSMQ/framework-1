// ============================================================================
// Project: Framework
// Name/Class: Paging
// Author: Joao Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using System.Linq;
using Framework.Core.Collections.Generic;

namespace Framework.Data.Query.Linq
{
    public static class Paging
    {
        //
        //
        //

        public static PagedValuesIndexList<TItem> Page<TItem>(this IQueryable<TItem> query, PagedIndexList page) where TItem : class
        {
            PagedValuesIndexList<TItem> output = new PagedValuesIndexList<TItem>();

            IQueryable<TItem> items = query.FromIndexPlusOne((page.CurrentPage - 1) * page.PageSize, page.PageSize);

            output.CurrentPage = page.CurrentPage;

            output.TotalNumberOfItems = query.Count();

            output.HasMore = items.Count() > page.PageSize;

            output.Values = items.Take(Math.Min(page.PageSize, items.Count())).ToList();

            output.PageSize = page.PageSize;

            output.Locale = page.Locale;

            return output;
        }

        //
        //
        //

        public static PagedValuesIndexList<TItem> PageExtra<TItem, TExtra>(this IQueryable<TItem> query, PagedExtraIndexList<TExtra> page) where TItem : class
        {
            PagedValuesIndexList<TItem> output = new PagedValuesIndexList<TItem>();

            IQueryable<TItem> items = query.FromIndexPlusOne((page.CurrentPage - 1) * page.PageSize, page.PageSize);

            output.CurrentPage = page.CurrentPage;

            output.TotalNumberOfItems = query.Count();

            if (page.PageSize == 0)
            {
                output.HasMore = false;

                output.Values = items.ToList();

                output.PageSize = items.Count();
            }
            else
            {
                output.HasMore = items.Count() > page.PageSize;

                output.Values = items.Take(Math.Min(page.PageSize, items.Count())).ToList();

                output.PageSize = page.PageSize;
            }

            output.Locale = page.Locale;

            return output;
        }
    }
}
