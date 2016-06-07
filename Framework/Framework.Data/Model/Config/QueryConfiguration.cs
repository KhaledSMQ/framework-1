// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model.Schema;
using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigQueryCollection : ConfigurationElementCollection
    {
        public ConfigQueryCollection() { }

        public ConfigQuery this[int index]
        {
            get { return (ConfigQuery)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigQuery serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigQuery();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigQuery)element).Name;
        }

        public void Remove(ConfigQuery serviceConfig)
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

    public class ConfigQuery : ConfigBase
    {
        //
        // KIND
        //

        [ConfigurationProperty(Constants.KIND, DefaultValue = TypeOfDataQuery.UNKNOWN, IsRequired = false)]
        public TypeOfDataQuery Kind
        {
            get { return (TypeOfDataQuery)this[Constants.KIND]; }
            set { this[Constants.KIND] = value; }
        }

        //
        // PARAMS
        //

        [ConfigurationProperty(Constants.PARAMS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigQueryParamCollection))]
        public ConfigQueryParamCollection Params
        {
            get { return (ConfigQueryParamCollection)this[Constants.PARAMS]; }
        }

        //
        // EXPRESSION
        //

        [ConfigurationProperty(Constants.EXPRESSION, DefaultValue = "", IsRequired = false)]
        public string Expression
        {
            get { return (string)this[Constants.EXPRESSION]; }
            set { this[Constants.EXPRESSION] = value; }
        }

        //
        // CALLBACK
        //

        [ConfigurationProperty(Constants.CALLBACK, DefaultValue = "", IsRequired = false)]
        public string Callback
        {
            get { return (string)this[Constants.CALLBACK]; }
            set { this[Constants.CALLBACK] = value; }
        }
    }
}
