// ============================================================================
// Project: Framework
// Name/Class: Configuration for Routes.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Web.Config.Routing
{
    public class RoutingElement : ConfigurationElement
    {
        //
        // HTTP ROUTE BASE URL
        //

        [ConfigurationProperty(Routing.Constants.HTTP_ROUTE_BASE_URL, DefaultValue = "_api", IsRequired = false)]
        public string HttpRouteBaseUrl
        {
            get { return (string)this[Routing.Constants.HTTP_ROUTE_BASE_URL]; }
            set { this[Routing.Constants.HTTP_ROUTE_BASE_URL] = value; }
        }

        //
        // PAGE ROUTES
        //

        [ConfigurationProperty(Routing.Constants.PAGES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(PageRouteElementCollection))]
        public PageRouteElementCollection Pages
        {
            get { return (PageRouteElementCollection)this[Routing.Constants.PAGES]; }
        }

        //
        // HTTP ROUTES
        //

        [ConfigurationProperty(Routing.Constants.HTTP, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(HttpRouteElementCollection))]
        public HttpRouteElementCollection Http
        {
            get { return (HttpRouteElementCollection)this[Routing.Constants.HTTP]; }
        }
    }
}
