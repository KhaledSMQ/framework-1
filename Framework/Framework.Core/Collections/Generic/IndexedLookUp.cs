// ============================================================================
// Project: Framework
// Name/Class: IndexedLookUp
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Core.Collections.Generic
{
    public class IndexedLookUp<TKey, T> : IIndexedLookUp<TKey, T> where T : class, IIndexedComponent<TKey>
    {
        //
        // Dictionary with all items ordered by id.
        //

        protected IDictionary<TKey, T> _DictByID;

        //
        // Dictionary with all items order by name.
        //

        protected IDictionary<string, T> _DictByName;

        //
        // List with all items.
        //

        protected IList<T> _List;

        //
        // Generic based lookup.
        //

        public IndexedLookUp(IList<T> allItems)
        {
            _List = allItems;
            _DictByID = new Dictionary<TKey, T>();
            _DictByName = new Dictionary<string, T>();
            Initialize(allItems);
        }

        //
        // Returns the location item given the id.
        //

        public virtual T this[TKey id]
        {
            get
            {
                if (!_DictByID.ContainsKey(id))
                {
                    return null;
                }
                return _DictByID[id];
            }
        }

        //
        // Returns the location item given the full name ("New York") or abbr ( "NY" )
        //

        public virtual T this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) { return null; }

                string lowerCaseName = name.Trim().ToLower();

                if (_DictByName.ContainsKey(lowerCaseName))
                {
                    return _DictByName[lowerCaseName];
                }

                return null;
            }
        }

        //
        // Get the number of items in this lookup.
        //

        public int Count
        {
            get { return _DictByID.Count; }
        }

        //
        // Initialize the internal lookup tables with the items.
        // Store them by id and name.
        //

        protected virtual void Initialize(IList<T> allItems)
        {
            foreach (T item in allItems)
            {
                // 
                // Store by id.
                //

                _DictByID[item.ID] = item;

                // 
                // Now store by name.
                //

                string namedKey = item.BuildKey();
                _DictByName[namedKey] = item;
            }
        }
    }
}
