// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Configuration;

namespace Framework.App.Config
{
    public class MethodCallElementCollection : ConfigurationElementCollection
    {
        public MethodCallElementCollection() { }

        public MethodCallElement this[int index]
        {
            get { return (MethodCallElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(MethodCallElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MethodCallElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MethodCallElement)element).GetHashCode();
        }

        public void Remove(MethodCallElement itemConfig)
        {
            BaseRemove(itemConfig.GetHashCode());
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

    public class MethodCallElement : ConfigurationElement
    {
        //
        // SERVICE
        //

        [ConfigurationProperty(Constants.SERVICE, DefaultValue = "", IsRequired = true)]
        public string Service
        {
            get { return (string)this[Constants.SERVICE]; }
            set { this[Constants.SERVICE] = value; }
        }

        //
        // METHOD
        //

        [ConfigurationProperty(Constants.METHOD, DefaultValue = "", IsRequired = false)]
        public string Method
        {
            get { return (string)this[Constants.METHOD]; }
            set { this[Constants.METHOD] = value; }
        }
    }
}
