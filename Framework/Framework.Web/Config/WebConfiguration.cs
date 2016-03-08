// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using Framework.Web.Config.Routing;
using System.Configuration;

namespace Framework.Web.Config
{
    public class WebConfiguration : ConfigurationSection
    {
        //
        // ROUTING
        //

        [ConfigurationProperty(Constants.ROUTING)]
        public RoutingElement Routing
        {
            get { return (RoutingElement)this[Constants.ROUTING]; }
        }  
    }
}
