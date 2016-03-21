// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class Param : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public Param()
        {
            ID = default(int);
            Name = default(string);
            Description = default(string);
            Type = default(string);
            Required = default(bool);
        }
    }
}
