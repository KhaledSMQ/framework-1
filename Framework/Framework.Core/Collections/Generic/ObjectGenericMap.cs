// ============================================================================
// Project: Framework
// Name/Class: ObjectGenericMap
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic map collection.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Extensions;

namespace Framework.Core.Objects
{
    public class ObjectGenericMap<K, T> : SortedDictionary<K, T>, IDictionary<K, T>
    {
        //
        // Error message for when the mapping contains a duplicate.
        // Use '{0}' in property value to place the duplicate item namespace
        // and name.
        //

        public string ErrorMsgTypeMappingDuplicate { get; set; }

        //
        // Error message for when the mapping does not exist in this instance.
        // Use '{0}' in property value to place the duplicate item namespace
        // and name.
        //

        public string ErrorMsgTypeMappingDoesNotExist { get; set; }

        //
        // Default constructor, initialize object mapper.
        // Initialize internal properties like the error messages.
        //

        public ObjectGenericMap()
            : base()
        {
            ErrorMsgTypeMappingDuplicate = Msg_ERROR_TYPE_MAPPING_DUPLICATE;
            ErrorMsgTypeMappingDoesNotExist = Msg_ERROR_TYPE_MAPING_DOES_NOT_EXIST;
        }

        public void Register(ObjectGenericMap<K, T> map, bool update = true)
        {
            this.Register(map.ToList<KeyValuePair<K, T>>(), update);
        }

        public void Register(IDictionary<K, T> dict, bool update = true)
        {
            this.Register(dict.ToList<KeyValuePair<K, T>>(), update);
        }

        public void Register(IList<KeyValuePair<K, T>> lst, bool update = true)
        {
            lst.Apply<KeyValuePair<K, T>>(v => this.Register(v.Key, v.Value, update));
        }

        public K Register(K key, T value, bool update = true)
        {
            if (!ContainsKey(key))
            {
                Add(key, value);
            }
            else
            {
                if (update)
                {
                    Remove(key);
                    Add(key, value);
                }
                else
                {
                    throw new Exception(String.Format(ErrorMsgTypeMappingDuplicate, key));
                }
            }

            return key;
        }

        public void Unregister(IList<K> lst, bool quiet = true)
        {
            lst.Apply<K>(k => Unregister(k, quiet));
        }

        public void Unregister(K key, bool quiet = true)
        {
            if (ContainsKey(key))
            {
                Remove(key);
            }
            else
            {
                if (!quiet)
                {
                    throw new Exception(String.Format(ErrorMsgTypeMappingDoesNotExist, key));
                }
            }
        }

        //
        // Return a list of the registered keys in this map.
        //

        public IList<K> KeysAsList()
        {
            return Keys.ToList<K>();
        }

        //
        // Return the list of values in this map.
        // In an arbitrary order.
        //

        public IList<T> ValuesAsList()
        {
            return Values.ToList<T>();
        }

        //
        // Filter the values in this map. USe a predicate to filter all the values
        // found in this mapping that return true to a specified predicate.
        //

        public IList<T> Filter(Predicate<T> filter)
        {
            return Values.ToList<T>().FindAll(filter);
        }

        //
        // Get a required mapping from this map structure. If mapping
        // is not found, then throw an exception.
        //

        public T GetRequired(K key)
        {
            T value = default(T);

            if (!TryGetValue(key, out value))
            {
                throw new Exception(String.Format(ErrorMsgTypeMappingDoesNotExist, key));
            }

            return value;
        }

        //
        // Check existent key in this object map. If key does
        // not exist, an exception is thrown.
        //

        public void CheckExistentKey(K key)
        {
            if (!ContainsKey(key))
            {
                throw new Exception(String.Format(ErrorMsgTypeMappingDoesNotExist, key));
            }
        }

        //
        // Check if a list of keys exist (all of them)
        //

        public void CheckExistentKey(IList<K> lst)
        {
            lst.Apply<K>(CheckExistentKey);
        }

        //
        // Method to verify that a key DOES NOT exist in this
        // mapping. If key already exists, throw an exception.
        //

        public void CheckNonExistentKey(K key)
        {
            if (ContainsKey(key))
            {
                throw new Exception(String.Format(ErrorMsgTypeMappingDuplicate, key));
            }
        }

        //
        // Check if a list of keys does not exist (all of them)
        //

        public void CheckNonExistentKey(IList<K> lst)
        {
            lst.Apply<K>(CheckNonExistentKey);
        }

        // Error message for when user attemps to add an already existing type mapping
        public static string Msg_ERROR_TYPE_MAPPING_DUPLICATE = "{0} already exists in type mapping table";

        // Error message for when user attemps to use a type mapping that dows not exist
        public static string Msg_ERROR_TYPE_MAPING_DOES_NOT_EXIST = "{0} does not exist in type mapping table";
    }
}
