// ============================================================================
// Project: Framework
// Name/Class: Configuration for Entities.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigEntityRefCollection : ConfigurationElementCollection
    {
        public ConfigEntityRefCollection() { }

        public ConfigEntityRef this[int index]
        {
            get { return (ConfigEntityRef)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigEntityRef elm)
        {
            BaseAdd(elm);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigEntityRef();
        }

        protected override object GetElementKey(ConfigurationElement elm)
        {
            return ((ConfigEntityRef)elm).Name;
        }

        public void Remove(ConfigEntityRef elm)
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

    public class ConfigEntityRef : ConfigBaseWithSettings { }
}
