// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigQueryParamCollection : ConfigurationElementCollection
    {
        public ConfigQueryParamCollection() { }

        public ConfigQueryParam this[int index]
        {
            get { return (ConfigQueryParam)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigQueryParam serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigQueryParam();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigQueryParam)element).Name;
        }

        public void Remove(ConfigQueryParam serviceConfig)
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

    public class ConfigQueryParam : ConfigBaseWithType
    {
        //
        // REQUIRED
        //

        [ConfigurationProperty(Constants.REQUIRED, DefaultValue = false, IsRequired = false)]
        public bool Required
        {
            get { return (bool)this[Constants.REQUIRED]; }
            set { this[Constants.REQUIRED] = value; }
        }

        //
        // DEFAULT
        //

        [ConfigurationProperty(Constants.DEFAULT, DefaultValue = "", IsRequired = false)]
        public string Default
        {
            get { return (string)this[Constants.DEFAULT]; }
            set { this[Constants.DEFAULT] = value; }
        }
    }
}
