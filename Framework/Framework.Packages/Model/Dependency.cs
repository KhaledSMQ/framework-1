// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Packages.Model
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
