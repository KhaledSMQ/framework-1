// ============================================================================
// Project: Framework
// Name/Class: Configuration for Entities.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using Framework.Data.Model;
using System.Configuration;

namespace Framework.Data.Config
{
    public class EntityElementCollection : ConfigurationElementCollection
    {
        public EntityElementCollection() { }

        public EntityElement this[int index]
        {
            get { return (EntityElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(EntityElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EntityElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EntityElement)element).Name;
        }

        public void Remove(EntityElement serviceConfig)
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

    public class EntityElement : BaseElementWithTypeAndSettings
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
    }
}
