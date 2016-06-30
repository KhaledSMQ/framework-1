// ============================================================================
// Project: Framework
// Name/Class: Configuration base element.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Factory.Model.Config
{
    public class ServiceElementCollection : ConfigurationElementCollection
    {
        public ServiceElementCollection() { }

        public ServiceElement this[int index]
        {
            get { return (ServiceElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ServiceElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceElement)element).Name;
        }

        public void Remove(ServiceElement itemConfig)
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

    public class ServiceElement : BaseElementWithTypeAndSettings
    { 
        //
        // CONTRACT
        //

        [ConfigurationProperty(Constants.CONTRACT, DefaultValue = "", IsRequired = true)]
        public string Contract
        {
            get { return (string)this[Constants.CONTRACT]; }
            set { this[Constants.CONTRACT] = value; }
        }

        [ConfigurationProperty(Constants.UNIQUE, DefaultValue = false, IsRequired = false)]
        public bool Unique
        {
            get { return (bool)this[Constants.UNIQUE]; }
            set { this[Constants.UNIQUE] = value; }
        }
    }
}
