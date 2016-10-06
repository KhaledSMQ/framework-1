// ============================================================================
// Project: Framework
// Name/Class: DictTypeConversion
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Semi-Generic based dictionary where the values are always 
//              strings which can be converted to any type using the public
//              conversion methods such  as GetInt(key), GetBool(key) etc.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class DictTypeConversion<TKey> : IDictionary<TKey, string>
    {
        //
        // Constructor requiring the generic dictionary being wrapped.
        //

        public DictTypeConversion()
        {
            _Dict = new Dictionary<TKey, string>();
        }

        //
        // Get the value associated with the key as a int.
        //

        public int GetInt(TKey key)
        {
            return Convert.ToInt32(this[key]);
        }

        //
        // Get the value associated with the key as a bool.
        //

        public bool GetBool(TKey key)
        {
            return Convert.ToBoolean(this[key]);
        }

        //
        // Get the value associated with the key as a string.
        //

        public string GetString(TKey key)
        {
            return this[key];
        }

        //
        // Get the value associated with the key as a double.
        //

        public double GetDouble(TKey key)
        {
            return Convert.ToDouble(this[key]);
        }

        //
        // Get the value associated with the key as a datetime.
        //

        public DateTime GetDateTime(TKey key)
        {
            return Convert.ToDateTime(this[key]);
        }

        //
        // Get the value associated with the key as a long.
        //

        public long GetLong(TKey key)
        {
            return Convert.ToInt64(this[key]);
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

        public string this[TKey key]
        {
            get { return _Dict[key]; }
            set { _Dict[key] = value; }
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

        public void Add(TKey key, string value)
        {
            _Dict.Add(key, value);
        }

        //
        // Not-supported.
        //

        public bool Remove(TKey key)
        {
            return _Dict.Remove(key);
        }

        //
        // Try to get the value.
        //

        public bool TryGetValue(TKey key, out string value)
        {
            value = string.Empty;

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

        public ICollection<string> Values
        {
            get { return _Dict.Values; }
        }

        //
        //

        public void Add(KeyValuePair<TKey, string> item)
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

        public bool Contains(KeyValuePair<TKey, string> item)
        {
            return _Dict.Contains(item);
        }

        //
        // Copy items to the array.
        //

        public void CopyTo(KeyValuePair<TKey, string>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<TKey, string> item)
        {
            return _Dict.Remove(item);
        }

        //
        // Get the enumerator.
        //

        public IEnumerator<KeyValuePair<TKey, string>> GetEnumerator()
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
        // PRIVATE FIELDS
        //

        private IDictionary<TKey, string> _Dict;
    }
}
