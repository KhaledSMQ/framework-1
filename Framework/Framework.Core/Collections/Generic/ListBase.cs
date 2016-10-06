// ============================================================================
// Project: Framework
// Name/Class: ListBase
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Class to serve as a base class for generic lists.
//              This is because the Generic list:
//                           System.Collections.Generic.List
//              is not meant to be extendable.
// ============================================================================

using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class ListBase<T> : IList<T>
    {
        //
        // CONSTRUCTORS
        //

        public ListBase()
        {
            _List = new List<T>();
        }

        //
        // Index of
        //

        public int IndexOf(T item)
        {
            return _List.IndexOf(item);
        }

        //
        // Insert.
        //

        public virtual void Insert(int index, T item)
        {
            _List.Insert(index, item);
        }

        //
        // Remove at the specified index.
        //

        public virtual void RemoveAt(int index)
        {
            _List.RemoveAt(index);
        }

        //
        // Accessor.
        //

        public virtual T this[int index]
        {
            get
            {
                return _List[index];
            }
            set
            {
                _List[index] = value;
            }
        }

        //
        // Add a list of models that should be shown in the dashboard on the sidebar.
        //

        public virtual void Add(params T[] items)
        {
            if (items == null || items.Length == 0)
            {
                return;
            }

            // 
            // Add the default definitions
            //

            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        //
        // Add
        //

        public virtual void Add(T item)
        {
            _List.Add(item);
        }

        //
        // Clear
        //

        public virtual void Clear()
        {
            _List.Clear();
        }

        //
        // Determines whether an item is
        // present in the current list.
        //

        public virtual bool Contains(T item)
        {
            return _List.Contains(item);
        }

        //
        // Copy to array.
        //

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            _List.CopyTo(array, arrayIndex);
        }

        //
        // Count of items.
        //

        public int Count
        {
            get { return _List.Count; }
        }

        //
        // Determine if is read only
        //

        public bool IsReadOnly
        {
            get { return _List.IsReadOnly; }
        }

        //
        // Removes the item.
        //

        public virtual bool Remove(T item)
        {
            return _List.Remove(item);
        }

        //
        // Returns an enumerator to the list.
        //

        public IEnumerator<T> GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        //
        // PROTECTED FIELDS
        //

        protected IList<T> _List;
    }
}
