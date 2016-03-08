// ============================================================================
// Project: Framework
// Name/Class: Configuration for Routes.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Collections;
using System.Configuration;

namespace Framework.Web.Config.Routing
{
    public class HttpRouteElementCollection : ConfigurationElementCollection, IEnumerable
    {
        public HttpRouteElementCollection() { }

        public HttpRouteElement this[int index]
        {
            get { return (HttpRouteElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(HttpRouteElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new HttpRouteElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HttpRouteElement)element).GetHashCode();
        }

        public void Remove(HttpRouteElement itemConfig)
        {
            BaseRemove(itemConfig.GetHashCode());
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
    }

    public class HttpRouteElement : ConfigurationElement
    {
        //
        // NAME
        //

        [ConfigurationProperty(Constants.NAME, DefaultValue = "", IsRequired = false)]
        public string Name
        {
            get { return (string)this[Constants.NAME]; }
            set { this[Constants.NAME] = value; }
        }

        //
        // TEMPLATES
        //

        [ConfigurationProperty(Constants.TEMPLATE, DefaultValue = "", IsRequired = true)]
        public string Template
        {
            get { return (string)this[Constants.TEMPLATE]; }
            set { this[Constants.TEMPLATE] = value; }
        }
    }
}
