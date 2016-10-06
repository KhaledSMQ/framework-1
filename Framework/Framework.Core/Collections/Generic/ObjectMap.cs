// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Implements a type mapping dictionary. 
//              Mapping a namespace/name combination to a generic value.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Types.Generic;
using Framework.Core.Patterns;

namespace Framework.Core.Objects
{
    public class ObjectMap<T> : ObjectGenericMap<string, T>, IObjectMap<T>, IDictionary<string, T>
    {
        //
        // Default namespace value for registered mappings.
        // To be used when user does not specify a namespace.
        //

        public string DefaultNamespace { get; set; }

        //
        // Default constructor, initialize object mapper.
        //

        public ObjectMap()
            : base()
        {
            DefaultNamespace = string.Empty;
        }

        //
        // Register another mapping. This method will traverse a list of type mapping
        // and insert them one by one. The update flag is applied to each insertion.
        //

        public void Register(ObjectMap<T> map, bool update = true)
        {
            foreach (KeyValuePair<string, T> def in map)
            {
                base.Register(def.Key, def.Value, update);
            }
        }

        //
        // Register a list of type mappings. This method will traverse a list of type mapping
        // and insert them one by one. The update flag is applied to each insertion.
        //

        public void Register(IList<Triple<string, string, T>> list, bool update = true)
        {
            foreach (Triple<string, string, T> def in list)
            {
                this.Register(def.First, def.Second, def.Third, update);
            }
        }

        //
        // Register a new type mapping in this table. This method will register a new
        // type mapping, in case the update flag is set to true, then if the mapping 
        // already exists, it is replaced. If this flag is set to false, then no replacement
        // is made and an exception is thrown. Uses default namespace property.
        //

        public new void Register(string name, T value, bool update = true)
        {
            this.Register(DefaultNamespace, name, value, update);
        }

        //
        // Register a new type mapping in this table. This method will register a new
        // type mapping, in case the update flag is set to true, then if the mapping 
        // already exists, it is replaced. If this flag is set to false, then no replacement
        // is made and an exception is thrown.
        //

        public void Register(string namespc, string name, T value, bool update = true)
        {
            base.Register(GetKey(namespc, name), value, update);
        }

        //
        // Register a dictionary of mappings. The mappings are defined
        // by a string to value mapping. It attaches the supplied namespace
        // to the registered mappings. Use default namespace property.
        //

        public new void Register(IDictionary<string, T> dict, bool update = true)
        {
            this.Register(DefaultNamespace, dict, update);
        }

        //
        // Register a dictionary of mappings. The mappings are defined
        // by a string to value mapping. It attaches the supplied namespace
        // to the registered mappings.
        //

        public void Register(string namespc, IDictionary<string, T> dict, bool update = true)
        {
            foreach (var val in dict)
            {
                base.Register(GetKey(namespc, val.Key), val.Value, update);
            }
        }

        //
        // Unregister the type mapping from table. This method will try to
        // unload the registered type mapping from this table. If the mapping
        // does not exist and the quit option is set to false, then this will throw
        // an exception. Uses default namespace property.
        //

        public new void Unregister(string name, bool quiet = true)
        {
            base.Unregister(GetKey(DefaultNamespace, name), quiet);
        }

        //
        // Unregister the type mapping from table. This method will try to
        // unload the registered type mapping from this table. If the mapping
        // does not exist and the quit option is set to false, then this will throw
        // an exception.
        //

        public void Unregister(string namespc, string name, bool quiet = true)
        {
            base.Unregister(GetKey(namespc, name), quiet);
        }

        //
        // Get a required mapping from this map structure. If mapping
        // is not found, then throw an exception. Uses default namespace property.
        //

        public new T GetRequired(string name)
        {
            return base.GetRequired(GetKey(DefaultNamespace, name));
        }

        //
        // Get a required mapping from this map structure. If mapping
        // is not found, then throw an exception.
        //

        public T GetRequired(string namespc, string name)
        {
            return base.GetRequired(GetKey(namespc, name));
        }

        //
        // Check existent key in this object map. If key does
        // not exist, an exception is thrown.
        //

        public new void CheckExistentKey(string key)
        {
            base.CheckExistentKey(GetKey(DefaultNamespace, key));
        }

        //
        // Check existent key in this object map. If key does
        // not exist, an exception is thrown.
        //

        public void CheckExistentKey(string namespc, string name)
        {
            base.CheckExistentKey(GetKey(namespc, name));
        }

        //
        // Method to verify that a key DOES NOT exist in this
        // mapping. If key already exists, throw an exception.
        //

        public new void CheckNonExistentKey(string key)
        {
            base.CheckNonExistentKey(GetKey(DefaultNamespace, key));
        }

        //
        // Method to verify that a key DOES NOT exist in this
        // mapping. If key already exists, throw an exception.
        //

        public void CheckNonExistentKey(string namespc, string name)
        {
            base.CheckNonExistentKey(GetKey(namespc, name));
        }

        //
        // Helper method to generate the key for the type mapping table.  We use a XML 
        // name notation to generate the key, combining namespace and name into one 
        // string, effectivaly creating a unique identifier.
        //

        protected string GetKey(string namespc, string name)
        {
            return "{" + namespc + "}" + name;
        }
    }
}
