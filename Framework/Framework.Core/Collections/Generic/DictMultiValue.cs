// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Dictionary based class to allow multiple values for a specific 
//              key.
// 
//  e.g. "searchsettings" = list{ setting1, setting2, setting3, .. settingN }
//
//              where setting1 and setting2 both are associated with keys.
// ============================================================================

using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class DictMultiValue<TKey, TValue>
    {
        //
        // CONSTRUCTORS
        //

        public DictMultiValue()
        {
            _Dict = new Dictionary<TKey, IList<TValue>>();
        }

        public DictMultiValue(IDictionary<TKey, IList<TValue>> dict)
        {
            _Dict = dict;
        }

        //
        // IDictionary<TKey, TValue>
        //

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
        // Returns the first of the multiple values associated with the key.
        //

        public TValue this[TKey key]
        {
            get
            {
                if (_Dict.ContainsKey(key))
                    return _Dict[key][0];

                return default(TValue);
            }
            set
            {
                // Add to existing.
                if (_Dict.ContainsKey(key))
                {
                    IList<TValue> valList = _Dict[key];
                    valList.Add(value);
                }
                else
                {
                    IList<TValue> list = new List<TValue>();
                    list.Add(value);
                    _Dict.Add(key, list);
                }
            }
        }

        //
        // Returns the entire list associated with the key.
        //

        public IList<TValue> Get(TKey key)
        {
            if (!_Dict.ContainsKey(key))
                return new List<TValue>();

            return _Dict[key];
        }

        //
        // Return keys.
        //

        public ICollection<TKey> Keys
        {
            get { return _Dict.Keys; }
        }

        //
        // Add the key-value.
        //

        public void Add(TKey key, TValue value)
        {
            this[key] = value;
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

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            if (_Dict.ContainsKey(key))
            {
                value = _Dict[key][0];
                return true;
            }
            return false;
        }

        //
        // Get the values.
        //

        public ICollection<IList<TValue>> Values
        {
            get
            {
                return _Dict.Values;
            }
        }

        //
        // ICollection<KeyValuePair<TKey, TValue>>
        //

        //
        // Not-supported.
        //

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        //
        // Clear the dictionary.
        //

        public void Clear()
        {
            _Dict.Clear();
        }

        //
        // Determine whether key value pair is in dictionary.
        //

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _Dict.ContainsKey(item.Key);
        }

        //
        // Copy items to the array.
        //

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            // TO_DO: Not supported presently.
            //this._dict.CopyTo(array, arrayIndex);
        }

        //
        // Indicate read-only
        //

        public bool IsReadOnly
        {
            get { return false; }
        }

        //
        // Non-supported action.
        //

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _Dict.Remove(item.Key);
        }

        //
        // IEnumerable<KeyValuePair<TKey, TValue>>
        //

        //
        // Get the enumerator.
        //

        public IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
        {
            return _Dict.GetEnumerator();
        }

        //
        // PRIVATE FIELDS
        //

        private IDictionary<TKey, IList<TValue>> _Dict;
    }
}
