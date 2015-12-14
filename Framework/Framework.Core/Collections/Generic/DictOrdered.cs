// ============================================================================
// Project: Framework
// Name/Class: DictOrdered
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: This class implements an ordered dictionary.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    [Serializable]
    public class DictOrdered<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //
        // CONTRUCTORS
        //

        public DictOrdered()
        {
            _List = new List<TKey>();
            _Dict = new Dictionary<TKey, TValue>();
        }

        //
        // IDictionary<TKey, TValue>
        //

        //
        // Add to key/value for both forward and reverse lookup.
        //

        public void Add(TKey key, TValue value)
        {
            _Dict.Add(key, value);
            _List.Add(key);
        }

        //
        // Determine if the key is contain in the forward lookup.
        //

        public bool ContainsKey(TKey key)
        {
            return _Dict.ContainsKey(key);
        }

        //
        // Get a list of all the keys in the forward lookup.
        //

        public ICollection<TKey> Keys
        {
            get { return _Dict.Keys; }
        }

        //
        // Remove the key from the ordered dictionary.
        //

        public bool Remove(TKey key)
        {
            if (!_Dict.ContainsKey(key))
            {
                return false;
            }

            int ndxKey = IndexOfKey(key);
            _Dict.Remove(key);
            _List.RemoveAt(ndxKey);

            return true;
        }

        //
        // Try to get the value from the forward lookup.
        //

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _Dict.TryGetValue(key, out value);
        }

        //
        // Get the collection of values.
        //

        public ICollection<TValue> Values
        {
            get { return _Dict.Values; }
        }

        //
        // Set the key / value for bi-directional lookup.
        //

        public TValue this[TKey key]
        {
            get
            {
                return _Dict[key];
            }
            set
            {
                if (_Dict.ContainsKey(key))
                {
                    _Dict[key] = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        //
        // ICollection<KeyValuePair<TKey, TValue>>
        //

        //
        // Add to ordered lookup.
        //

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item);
        }

        //
        // Clears keys/value for bi-directional lookup.
        //
        public void Clear()
        {
            _Dict.Clear();
            _List.Clear();
        }

        //
        // Determine if the item is in the forward lookup.
        //

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _Dict.Contains(item);
        }

        //
        // Copies the array of key/value pairs for both ordered dictionary.
        // TO_DO: This needs to implemented.
        //

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _Dict.CopyTo(array, arrayIndex);
        }

        //
        // Get number of entries.
        //

        public int Count
        {
            get { return _Dict.Count; }
        }

        //
        // Get whether or not this is read-only.
        //

        public bool IsReadOnly
        {
            get { return _Dict.IsReadOnly; }
        }

        //
        // Remove the item.
        //

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!_Dict.ContainsKey(item.Key))
            {
                return false;
            }

            int ndxOfKey = IndexOfKey(item.Key);
            _List.RemoveAt(ndxOfKey);
            return _Dict.Remove(item);
        }

        //
        // IEnumerable<KeyValuePair<TKey, TValue>>
        //

        //
        // Get the enumerator for the forward lookup.
        //

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // IEnumerable
        //

        //
        // Get the enumerator for the forward lookup.
        //

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // IList
        //

        //
        // Insert key/value at the specified index.
        //

        public void Insert(int index, TKey key, TValue value)
        {
            _Dict.Add(key, value);
            _List.Insert(index, key);
        }

        //
        // Get the index of the key.
        //

        public int IndexOfKey(TKey key)
        {
            if (!_Dict.ContainsKey(key))
            {
                return -1;
            }

            for (int ndx = 0; ndx < _List.Count; ndx++)
            {
                TKey keyInList = _List[ndx];
                if (keyInList.Equals(key))
                {
                    return ndx;
                }
            }

            return -1;
        }

        //
        // Remove the key/value item at the specified index.
        //

        public void RemoveAt(int index)
        {
            TKey key = _List[index];
            _Dict.Remove(key);
            _List.RemoveAt(index);
        }

        //
        // Get/set the value at the specified index.
        //

        public TValue this[int index]
        {
            get
            {
                TKey key = _List[index];
                return _Dict[key];
            }
            set
            {
                TKey key = _List[index];
                _Dict[key] = value;
            }
        }

        //
        // PRIVATE FIELDS
        //

        private IList<TKey> _List = null;
        private IDictionary<TKey, TValue> _Dict = null;
    }
}