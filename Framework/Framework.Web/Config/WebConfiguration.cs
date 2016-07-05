// ============================================================================
// Project: Framework
// Name/Class: Configuration for Manager.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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
