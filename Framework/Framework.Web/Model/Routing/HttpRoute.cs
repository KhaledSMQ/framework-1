// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

namespace Framework.Web.Model.Routing
{
    public class HttpRoute
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Template { get; set; }

        //
        // CONSTRUCTORS
        // 

        public HttpRoute(string name, string template)
        {
            Name = name;
            Template = template;
        }

        public HttpRoute() : this(string.Empty, string.Empty) { }
    }
}
