// ============================================================================
// Project: Framework
// Name/Class: DictSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections;
using System.Collections.Generic;
using Framework.Core.Helpers;

namespace Framework.Core.Collections.Generic
{
    public class DictSet<T> : IDictionary<T, T>, Framework.Core.Patterns.ISet<T>
    {
        //
        // CONSTRUCTORS
        //

        public DictSet()
        {
            _Dict = new Dictionary<T, T>();
        }

        //
        // IDictionary<T,T>
        //

        //
        // Determine if the underlying collection contains the key.
        //

        public bool ContainsKey(T key)
        {
            return _Dict.ContainsKey(key);
        }

        //
        // Number of items in the dictionary.
        //

        public int Count
        {
            get { return _Dict.Count; }
        }

        //
        // Returns the value associated with the key.
        //

        public T this[T key]
        {
            get { return _Dict[key]; }
            set { _Dict[key] = value; }
        }

        //
        // Return keys.
        //

        public ICollection<T> Keys
        {
            get { return _Dict.Keys; }
        }

        //
        //

        public void Add(T key, T value)
        {
            _Dict.Add(key, value);
        }

        //        
        //

        public bool Remove(T key)
        {
            return _Dict.Remove(key);
        }

        //
        // Try to get the value.
        //

        public bool TryGetValue(T key, out T value)
        {
            value = default(T);

            if (_Dict.ContainsKey(key))
            {
                value = _Dict[key];
                return true;
            }

            return false;
        }

        //
        // Get the values.
        //

        public ICollection<T> Values
        {
            get { return _Dict.Values; }
        }

        //
        // ICollection<KeyValuePair<T,T>>
        //

        //
        //

        public void Add(KeyValuePair<T, T> item)
        {
            _Dict.Add(item);
        }

        //
        //

        public void Clear()
        {
            _Dict.Clear();
        }

        //
        // Determine whether key value pair is in dictionary.
        //

        public bool Contains(KeyValuePair<T, T> item)
        {
            return _Dict.Contains(item);
        }

        //
        // Copy items to the array.
        //

        public void CopyTo(KeyValuePair<T, T>[] array, int arrayIndex)
        {
            this._Dict.CopyTo(array, arrayIndex);
        }

        //
        // Indicate read-only
        //

        public bool IsReadOnly
        {
            get { return true; }
        }

        //
        //

        public bool Remove(KeyValuePair<T, T> item)
        {
            return _Dict.Remove(item);
        }

        //
        // IEnumerable<KeyValuePair<T,T>>
        //

        //
        // Get the enumerator.
        //

        public IEnumerator<KeyValuePair<T, T>> GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // IEnumerable
        //

        //
        // Get the enumerator.
        //

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // ICollection<T>
        //

        //
        // Adds an item to collection.
        //

        public void Add(T item)
        {
            _Dict.Add(item, item);
        }

        //
        // Determines whether the <see cref="T:ICollection`1"/> contains a specific value.
        //

        public bool Contains(T item)
        {
            return _Dict.ContainsKey(item);
        }

        //
        // Copies the elements of the <see cref="T:ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        //

        public void CopyTo(T[] array, int arrayIndex)
        {
        }

        //
        // IEnumerable<T>
        //

        //
        // Returns an enumerator that iterates through the collection.
        //

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _Dict.Keys.GetEnumerator();
        }

        //
        // ISet
        //

        //
        // Unions the specified other.
        //

        public Framework.Core.Patterns.ISet<T> Union(Framework.Core.Patterns.ISet<T> other)
        {
            return SetHelper<T>.Union(this, other);
        }

        //
        // Intersects the specified other.
        //

        public Framework.Core.Patterns.ISet<T> Intersect(Framework.Core.Patterns.ISet<T> other)
        {
            return SetHelper<T>.Intersect(this, other);
        }

        //
        // Exclusives the or.
        //

        public Framework.Core.Patterns.ISet<T> ExclusiveOr(Framework.Core.Patterns.ISet<T> other)
        {
            return SetHelper<T>.ExclusiveOr(this, other);
        }

        //
        // Minuses the specified other.
        //

        public Framework.Core.Patterns.ISet<T> Minus(Framework.Core.Patterns.ISet<T> other)
        {
            return SetHelper<T>.Minus(this, other);
        }

        //
        // PRIVATE FIELDS
        //

        private IDictionary<T, T> _Dict;
    }
}
