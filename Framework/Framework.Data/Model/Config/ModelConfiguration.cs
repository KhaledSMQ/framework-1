// ============================================================================
// Project: Framework
// Name/Class: Configuration for Models.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigModelCollection : ConfigurationElementCollection
    {
        public ConfigModelCollection() { }

        public ConfigModel this[int index]
        {
            get { return (ConfigModel)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigModel serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigModel();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigModel)element).Name;
        }

        public void Remove(ConfigModel serviceConfig)
        {
            BaseRemove(serviceConfig.Name);
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

    public class ConfigModel : ConfigBaseWithTypeAndSettings { }
}
