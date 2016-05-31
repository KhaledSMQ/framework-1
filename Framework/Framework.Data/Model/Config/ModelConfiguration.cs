// ============================================================================
// Project: Framework
// Name/Class: Configuration for Models.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ModelElementCollection : ConfigurationElementCollection
    {
        public ModelElementCollection() { }

        public ModelElement this[int index]
        {
            get { return (ModelElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ModelElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ModelElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModelElement)element).Name;
        }

        public void Remove(ModelElement serviceConfig)
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

    public class ModelElement : BaseElementWithTypeAndSettings { }
}
