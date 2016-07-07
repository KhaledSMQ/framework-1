// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

using Framework.Web.Config.Routing;
using System.Configuration;

namespace Framework.Web.Config
{
    public class LibConfiguration : Configuration.Model.Config.ModuleConfiguration    
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
