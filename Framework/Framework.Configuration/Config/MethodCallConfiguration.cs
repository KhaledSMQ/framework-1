// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Configuration;

namespace Framework.Configuration.Config
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

        [ConfigurationProperty(_Const.SERVICE, DefaultValue = "", IsRequired = true)]
        public string Service
        {
            get { return (string)this[_Const.SERVICE]; }
            set { this[_Const.SERVICE] = value; }
        }

        //
        // METHOD
        //

        [ConfigurationProperty(_Const.METHOD, DefaultValue = "", IsRequired = false)]
        public string Method
        {
            get { return (string)this[_Const.METHOD]; }
            set { this[_Const.METHOD] = value; }
        }
    }
}
