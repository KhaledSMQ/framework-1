// ============================================================================
// Project: Framework
// Name/Class: Configuration for Settings.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigSettingCollection : ConfigurationElementCollection
    {
        public ConfigSettingCollection() { }

        public ConfigSetting this[int index]
        {
            get { return (ConfigSetting)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigSetting serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigSetting)element).Name;
        }

        public void Remove(ConfigSetting serviceConfig)
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

    public class ConfigSetting : ConfigBase {

        //
        // Value
        //

        [ConfigurationProperty(Constants.VALUE, DefaultValue = "", IsRequired = true)]
        public string Value
        {
            get { return (string)this[Constants.VALUE]; }
            set { this[Constants.VALUE] = value; }
        }
    }
}
