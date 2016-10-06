// ============================================================================
// Project: Framework
// Name/Class: Library Configuration.
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Configuration for this module/library.
// ============================================================================

using System.Configuration;

namespace Framework.Web.Model.Config
{
    public class LibConfiguration : Core.Config.ModuleConfiguration    
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
