// ============================================================================
// Project: Framework
// Name/Class: Configuration for contexts.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Config
{
    public class ContextElementCollection : ConfigurationElementCollection
    {
        public ContextElementCollection() { }

        public ContextElement this[int index]
        {
            get { return (ContextElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ContextElement elm)
        {
            BaseAdd(elm);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ContextElement();
        }

        protected override object GetElementKey(ConfigurationElement elm)
        {
            return ((ContextElement)elm).Name;
        }

        public void Remove(ContextElement elm)
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

    public class ContextElement : BaseElement
    { 
        //
        // PROVIDER
        //

        [ConfigurationProperty(Constants.PROVIDER, IsRequired = true)]
        public ProviderElement Provider
        {
            get { return (ProviderElement)this[Constants.PROVIDER]; }
        }

        //
        // ENTITY-REFS
        //

        [ConfigurationProperty(Constants.ENTITIES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(EntityRefElementCollection))]
        public EntityRefElementCollection Entities
        {
            get { return (EntityRefElementCollection)this[Constants.ENTITIES]; }
        }

        //
        // MODEL-REFS
        //

        [ConfigurationProperty(Constants.MODELS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ModelRefElementCollection))]
        public ModelRefElementCollection Models
        {
            get { return (ModelRefElementCollection)this[Constants.MODELS]; }
        }
    }
}
