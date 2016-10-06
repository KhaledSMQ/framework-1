// ============================================================================
// Project: Framework
// Name/Class: Configuration for Routes.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Web.Config
{
    public class RoutingElement : ConfigurationElement
    {
        //
        // HTTP ROUTE BASE URL
        //

        [ConfigurationProperty(Constants.ROUTING_HTTP_ROUTE_BASE_URL, DefaultValue = "_api", IsRequired = false)]
        public string HttpRouteBaseUrl
        {
            get { return (string)this[Constants.ROUTING_HTTP_ROUTE_BASE_URL]; }
            set { this[Constants.ROUTING_HTTP_ROUTE_BASE_URL] = value; }
        }

        //
        // PAGE ROUTES
        //

        [ConfigurationProperty(Constants.ROUTING_PAGES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(PageRouteElementCollection))]
        public PageRouteElementCollection Pages
        {
            get { return (PageRouteElementCollection)this[Constants.ROUTING_PAGES]; }
        }

        //
        // HTTP ROUTES
        //

        [ConfigurationProperty(Constants.ROUTING_HTTP, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(HttpRouteElementCollection))]
        public HttpRouteElementCollection Http
        {
            get { return (HttpRouteElementCollection)this[Constants.ROUTING_HTTP]; }
        }
    }
}
