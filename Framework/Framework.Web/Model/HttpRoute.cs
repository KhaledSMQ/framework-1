// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 08/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

namespace Framework.Web.Model
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
