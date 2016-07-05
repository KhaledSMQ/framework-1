// ============================================================================
// Project: Framework
// Name/Class: Configuration for contexts.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigContextCollection : ConfigurationElementCollection
    {
        public ConfigContextCollection() { }

        public ConfigContext this[int index]
        {
            get { return (ConfigContext)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigContext elm)
        {
            BaseAdd(elm);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigContext();
        }

        protected override object GetElementKey(ConfigurationElement elm)
        {
            return ((ConfigContext)elm).Name;
        }

        public void Remove(ConfigContext elm)
        {
            BaseRemove(elm.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }

    public class ConfigContext : ConfigBase
    { 
        //
        // PROVIDER
        //

        [ConfigurationProperty(Constants.PROVIDER, IsRequired = true)]
        public ConfigProvider Provider
        {
            get { return (ConfigProvider)this[Constants.PROVIDER]; }
        }

        //
        // ENTITY-REFS
        //

        [ConfigurationProperty(Constants.ENTITIES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigEntityRefCollection))]
        public ConfigEntityRefCollection Entities
        {
            get { return (ConfigEntityRefCollection)this[Constants.ENTITIES]; }
        }

        //
        // MODEL-REFS
        //

        [ConfigurationProperty(Constants.MODELS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigModelRefCollection))]
        public ConfigModelRefCollection Models
        {
            get { return (ConfigModelRefCollection)this[Constants.MODELS]; }
        }
    }
}
