// ============================================================================
// Project: Framework
// Name/Class: Configuration for Entities.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using Framework.Data.Model.Relational;
using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigEntityCollection : ConfigurationElementCollection
    {
        public ConfigEntityCollection() { }

        public ConfigEntity this[int index]
        {
            get { return (ConfigEntity)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigEntity serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigEntity();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigEntity)element).Name;
        }

        public void Remove(ConfigEntity serviceConfig)
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

    public class ConfigEntity : ConfigBaseWithTypeAndSettings
    {
        //
        // KIND
        //

        [ConfigurationProperty(Constants.KIND, DefaultValue = TypeOfDataEntity.DATA_SET, IsRequired = false)]
        public TypeOfDataEntity Kind
        {
            get { return (TypeOfDataEntity)this[Constants.KIND]; }
            set { this[Constants.KIND] = value; }
        }

        //
        // QUERIES
        //

        [ConfigurationProperty(Constants.QUERIES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigQueryCollection))]
        public ConfigQueryCollection Queries
        {
            get { return (ConfigQueryCollection)this[Constants.QUERIES]; }
        }
    }
}
