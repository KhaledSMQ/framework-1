// ============================================================================
// Project: Framework
// Name/Class: Configuration for Routes.
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Collections;
using System.Configuration;

namespace Framework.Web.Config
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

        [ConfigurationProperty(Constants.ROUTING_NAME, DefaultValue = "", IsRequired = false)]
        public string Name
        {
            get { return (string)this[Constants.ROUTING_NAME]; }
            set { this[Constants.ROUTING_NAME] = value; }
        }

        //
        // TEMPLATES
        //

        [ConfigurationProperty(Constants.ROUTING_TEMPLATE, DefaultValue = "", IsRequired = true)]
        public string Template
        {
            get { return (string)this[Constants.ROUTING_TEMPLATE]; }
            set { this[Constants.ROUTING_TEMPLATE] = value; }
        }
    }
}
