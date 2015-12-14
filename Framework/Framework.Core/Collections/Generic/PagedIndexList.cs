// ============================================================================
// Project: Toolkit
// Name/Class: PagedIndexList
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    [Serializable]
    public class PagedValuesIndexList<T> : PagedIndexList<T, object>
    {
        public PagedValuesIndexList()
        {
            Values = new List<T>();
        }

        //
        // TODO: CloneWithValues with repeated code! Optimize!
        //

        public new PagedValuesIndexList<TN> CloneWithValues<TN>(IList<TN> lstOfValues)
        {
            PagedValuesIndexList<TN> output = new PagedValuesIndexList<TN>();
            output.HasMore = this.HasMore;
            output.PageSize = this.PageSize;
            output.TotalNumberOfItems = this.TotalNumberOfItems;
            output.CurrentPage = this.CurrentPage;
            output.Values = lstOfValues;
            output.Extra = this.Extra;
            output.Locale = this.Locale;
            return output;
        }
    }

    [Serializable]
    public class PagedExtraIndexList<TExtra> : PagedIndexList<object, TExtra>
    {
        //
        // TODO: CloneWithValues with repeated code! Optimize!
        //

        public new PagedValuesIndexList<TN> CloneWithValues<TN>(IList<TN> lstOfValues)
        {
            PagedValuesIndexList<TN> output = new PagedValuesIndexList<TN>();
            output.HasMore = this.HasMore;
            output.PageSize = this.PageSize;
            output.TotalNumberOfItems = this.TotalNumberOfItems;
            output.CurrentPage = this.CurrentPage;
            output.Values = lstOfValues;
            output.Extra = this.Extra;
            output.Locale = this.Locale;
            return output;
        }

    }

    [Serializable]
    public class PagedIndexList : PagedIndexList<object, object> { }

    [Serializable]
    public class PagedIndexList<TItem, TExtra>
    {
        //
        // PROPERTIES
        //

        public IList<TItem> Values { get; set; }

        //
        // Whether the datasource has more elements.
        //

        public bool HasMore { get; set; }

        //
        // Required in client side calls.
        // Defines the number of items per page.
        //

        public int PageSize { get; set; }

        //
        // Total number of items in the data source.
        //

        public int TotalNumberOfItems { get; set; }

        //
        // The current page in the paging process.
        //

        public int CurrentPage { get; set; }

        //
        // The locale for the returned list items. 
        //

        public string Locale { get; set; }

        //
        // Extra info
        //

        public TExtra Extra { get; set; }


        //
        // CONSTRUCTORS
        //

        public PagedIndexList() : this(null, false, -1, 0) { }

        public PagedIndexList(IList<TItem> values, bool hasMore, int startIndex, int pageSize)
            : base()
        {
            Values = values;
            HasMore = hasMore;
            PageSize = pageSize;
        }

        //
        // STANDARD
        // 

        public virtual PagedIndexList<TN, TExtra> CloneWithValues<TN>(IList<TN> lstOfValues)
        {
            PagedIndexList<TN, TExtra> output = new PagedIndexList<TN, TExtra>();
            output.HasMore = this.HasMore;
            output.PageSize = this.PageSize;
            output.TotalNumberOfItems = this.TotalNumberOfItems;
            output.CurrentPage = this.CurrentPage;
            output.Values = lstOfValues;
            output.Extra = this.Extra;
            output.Locale = this.Locale;
            return output;
        }

        public PagedIndexList ToPagedIndexListWithoutValues()
        {
            PagedIndexList output = new PagedIndexList();

            output.HasMore = this.HasMore;
            output.PageSize = this.PageSize;
            output.TotalNumberOfItems = this.TotalNumberOfItems;
            output.CurrentPage = this.CurrentPage;
            output.Locale = this.Locale;

            return output;
        }
    }
}
