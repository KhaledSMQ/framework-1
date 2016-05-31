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
    public class EntityRefElementCollection : ConfigurationElementCollection
    {
        public EntityRefElementCollection() { }

        public EntityRefElement this[int index]
        {
            get { return (EntityRefElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(EntityRefElement elm)
        {
            BaseAdd(elm);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EntityRefElement();
        }

        protected override object GetElementKey(ConfigurationElement elm)
        {
            return ((EntityRefElement)elm).Name;
        }

        public void Remove(EntityRefElement elm)
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

    public class EntityRefElement : BaseElementWithSettings { }
}
