// ============================================================================
// Project: Framework
// Name/Class: DictBidirectional
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Dictionary for bidirectional lookup.
// ============================================================================

using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class DictBidirectional<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //
        // CONSTRUCTORS
        //

        public DictBidirectional() { }

        public DictBidirectional(IDictionary<TKey, TValue> forward, IDictionary<TValue, TKey> reverse)
        {
            _ForwardMap = forward;
            _ReverseMap = reverse;
        }

        //
        // IDictionary<TKey, TValue>
        //

        //
        // Add to key/value for both forward and reverse lookup.
        //

        public void Add(TKey key, TValue value)
        {
            _ForwardMap.Add(key, value);
            _ReverseMap.Add(value, key);
        }

        //
        // Determine if the key is contained in the forward lookup.
        //

        public bool ContainsKey(TKey key)
        {
            return _ForwardMap.ContainsKey(key);
        }

        //
        // Get a list of all the keys in the forward lookup.
        //

        public ICollection<TKey> Keys
        {
            get { return _ForwardMap.Keys; }
        }

        //
        // Remove the key for both forward and reverse lookup.
        //

        public bool Remove(TKey key)
        {
            _ReverseMap.Remove(_ForwardMap[key]);
            return _ForwardMap.Remove(key);
        }

        //
        // Try to get the value from the forward lookup.
        //

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _ForwardMap.TryGetValue(key, out value);
        }

        //
        // Get the collection of values.
        //

        public ICollection<TValue> Values
        {
            get { return _ForwardMap.Values; }
        }

        //
        // Set the key / value for bi-directional lookup.
        //

        public TValue this[TKey key]
        {
            get
            {
                return _ForwardMap[key];
            }
            set
            {
                _ForwardMap[key] = value;
                _ReverseMap[value] = key;
            }
        }

        //
        // ICollection<KeyValuePair<TKey, TValue>>
        //

        //
        // Add to bi-directional lookup.
        // @param item The key/value item to add
        //

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _ForwardMap.Add(item);
            _ReverseMap.Add(new KeyValuePair<TValue, TKey>(item.Value, item.Key));
        }

        //
        // Clears keys/value for bi-directional lookup.
        //

        public void Clear()
        {
            _ForwardMap.Clear();
            _ReverseMap.Clear();
        }

        //
        // Determine if the item is in the forward lookup.
        // @param item The item to check
        // @return True if item exists, false otherwise
        //

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _ForwardMap.Contains(item);
        }

        //
        // Copies the array of key/value pairs for both bi-directionaly lookups.
        // TO_DO: This needs to be unit-tested since, I don't think I'm handling
        // the _reverseMap correctly.
        //

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _ForwardMap.CopyTo(array, arrayIndex);
        }

        //
        // Get number of entries.
        //

        public int Count
        {
            get { return _ForwardMap.Count; }
        }

        //
        // Get whether or not this is read-only.
        //

        public bool IsReadOnly
        {
            get { return _ForwardMap.IsReadOnly; }
        }

        //
        // Remove the item from bi-directional lookup.
        // @param item The item to remove
        //

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            _ReverseMap.Remove(item.Value);
            return _ForwardMap.Remove(item);
        }

        //
        // IEnumerable<KeyValuePair<TKey, TValue>>
        //

        //
        // Get the enumerator for the forward lookup.
        // @return The enumerator
        //

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _ForwardMap.GetEnumerator();
        }

        //
        // IEnumerable
        //

        //
        // Get the enumerator for the forward lookup.
        // @return The enumerator
        //

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _ForwardMap.GetEnumerator();
        }

        //
        // Public Reverse Lookup Methods
        //

        //
        // Determine whether or not the reverse lookup contains the key
        // represented by the value.
        // @param value The value to check
        // @return True if key exists, false otherwise
        //

        public bool ContainsValue(TValue value)
        {
            return _ReverseMap.ContainsKey(value);
        }

        //
        // Determine whether or the reverse lookup ( value ) exists.
        // @param value The value to check
        // @return The key if exists
        //

        public TKey ContainsReverseLookup(TValue value)
        {
            return _ReverseMap[value];
        }

        //
        // Determine whether or the reverse lookup ( value ) exists.
        // @param value The value to check
        // @return The key if exists
        //

        public TKey KeyFor(TValue value)
        {
            return _ReverseMap[value];
        }

        //
        // PRIVATE FIELDS
        //

        private IDictionary<TKey, TValue> _ForwardMap = new Dictionary<TKey, TValue>();
        private IDictionary<TValue, TKey> _ReverseMap = new Dictionary<TValue, TKey>();
    }
}
