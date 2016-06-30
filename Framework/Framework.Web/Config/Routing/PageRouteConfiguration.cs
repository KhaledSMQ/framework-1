// ============================================================================
// Project: Framework
// Name/Class: Configuration for Routes.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Collections;
using System.Configuration;

namespace Framework.Web.Config.Routing
{
    public class PageRouteElementCollection : ConfigurationElementCollection, IEnumerable
    {
        public PageRouteElementCollection() { }

        public PageRouteElement this[int index]
        {
            get { return (PageRouteElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(PageRouteElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PageRouteElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PageRouteElement)element).GetHashCode();
        }

        public void Remove(PageRouteElement itemConfig)
        {
            BaseRemove(itemConfig.GetHashCode());
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
    }

    public class PageRouteElement : ConfigurationElement
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
        // FRIENDLY URL
        //

        [ConfigurationProperty(Constants.FRIENDLY_URL, DefaultValue = "", IsRequired = true)]
        public string FriendlyUrl
        {
            get { return (string)this[Constants.FRIENDLY_URL]; }
            set { this[Constants.FRIENDLY_URL] = value; }
        }

        //
        // LOCATION
        //

        [ConfigurationProperty(Constants.LOCATION, DefaultValue = "", IsRequired = true)]
        public string Location
        {
            get { return (string)this[Constants.LOCATION]; }
            set { this[Constants.LOCATION] = value; }
        }
    }
}
