// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Packages.Model.Objects
{
    public class Dependency : IID<string>
    {
        //
        // PROPERTIES
        //

        public string ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        //
        // CONSTRUCTORS
        //

        public Dependency()
        {
            ID = string.Empty;
            Name = string.Empty;
            Url = string.Empty;
        }
    }
}
