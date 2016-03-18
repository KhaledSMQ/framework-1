// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Configuration;

namespace Framework.Data.Config
{
    public class QueryParamElementCollection : ConfigurationElementCollection
    {
        public QueryParamElementCollection() { }

        public QueryParamElement this[int index]
        {
            get { return (QueryParamElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(QueryParamElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new QueryParamElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((QueryParamElement)element).Name;
        }

        public void Remove(QueryParamElement serviceConfig)
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

    public class QueryParamElement : BaseElementWithType
    {
        //
        // REQUIRED
        //

        [ConfigurationProperty(Constants.REQUIRED, DefaultValue = false, IsRequired = false)]
        public bool Required
        {
            get { return (bool)this[Constants.REQUIRED]; }
            set { this[Constants.REQUIRED] = value; }
        }

        //
        // DEFAULT
        //

        [ConfigurationProperty(Constants.DEFAULT, DefaultValue = "", IsRequired = false)]
        public string Default
        {
            get { return (string)this[Constants.DEFAULT]; }
            set { this[Constants.DEFAULT] = value; }
        }
    }
}
