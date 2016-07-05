// ============================================================================
// Project: Framework
// Name/Class: DictReadOnly
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Read only wrapper for generics based dictionary.
//              Only provides lookup retrieval abilities.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Core.Error;

namespace Framework.Core.Collections.Generic
{
    public class DictReadOnly<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //
        // CONSTRUCTORS
        //

        public DictReadOnly(IDictionary<TKey, TValue> items)
        {
            _ThrowOnWritableAction = true;
            _Dict = items;
        }

        public DictReadOnly(IDictionary<TKey, TValue> items, bool throwOnWritableAction)
        {
            _ThrowOnWritableAction = throwOnWritableAction;
            _Dict = items;
        }

        //
        // Determine if the underlying collection contains the key.
        //

        public bool ContainsKey(TKey key)
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

        public TValue this[TKey key]
        {
            get { return _Dict[key]; }
            set
            {
                _CheckAndThrow("Set");
            }
        }

        //
        // Return keys.
        //

        public ICollection<TKey> Keys
        {
            get { return _Dict.Keys; }
        }

        //
        // Not-supported.
        //        

        public void Add(TKey key, TValue value)
        {
            _CheckAndThrow("Add");
        }

        //
        // Not-supported.
        //

        public bool Remove(TKey key)
        {
            _CheckAndThrow("Remove");
            return false;
        }

        //
        // Try to get the value.
        //

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

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

        public ICollection<TValue> Values
        {
            get { return _Dict.Values; }
        }

        //
        // Not-supported.
        //

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _CheckAndThrow("Add");
        }

        //
        // Not-Supported.
        //

        public void Clear()
        {
            _CheckAndThrow("Clear");
        }

        //
        // Determine whether key value pair is in dictionary.
        //

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _Dict.Contains(item);
        }

        //
        // Copy items to the array.
        //

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
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
        // Non-supported action.
        //

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            _CheckAndThrow("Remove");
            return false;
        }

        //
        // Get the enumerator.
        //

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // Get the enumerator.
        //

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // HELPERS
        //

        //
        // Check and thrown based on flag.
        //

        private void _CheckAndThrow(string action)
        {
            if (_ThrowOnWritableAction)
            {
                Throw.WithPrefix(typeof(InvalidOperationException), Lib.DEFAULT_ERROR_MSG_PREFIX, "Can not perform action '{0}' on this read-only collection.", action);
            }
        }

        //
        // PRIVATE FIELDS
        //

        private IDictionary<TKey, TValue> _Dict;
        private bool _ThrowOnWritableAction = false;
    }
}
