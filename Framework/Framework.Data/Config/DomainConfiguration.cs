// ============================================================================
// Project: Framework
// Name/Class: Configuration for Domains.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Config
{
    public class DomainElementCollection : ConfigurationElementCollection
    {
        public DomainElementCollection() { }

        public DomainElement this[int index]
        {
            get { return (DomainElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(DomainElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DomainElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DomainElement)element).Name;
        }

        public void Remove(DomainElement itemConfig)
        {
            BaseRemove(itemConfig.Name);
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

    public class DomainElement : BaseElementWithSettings
    {
        //
        // CLUSTERS
        //

        [ConfigurationProperty(Constants.CLUSTERS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ClusterElementCollection))]
        public ClusterElementCollection Contexts
        {
            get { return (ClusterElementCollection)this[Constants.CLUSTERS]; }
        }         
    }
}
