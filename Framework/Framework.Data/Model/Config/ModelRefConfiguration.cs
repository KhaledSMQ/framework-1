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
    public class ModelRefElementCollection : ConfigurationElementCollection
    {
        public ModelRefElementCollection() { }

        public ModelRefElement this[int index]
        {
            get { return (ModelRefElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ModelRefElement elm)
        {
            BaseAdd(elm);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ModelRefElement();
        }

        protected override object GetElementKey(ConfigurationElement elm)
        {
            return ((ModelRefElement)elm).Name;
        }

        public void Remove(ModelRefElement elm)
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

    public class ModelRefElement : BaseElementWithSettings { }
}
