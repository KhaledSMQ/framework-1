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
    public class BlkParam : IID<int>
    {
        //
        // Numeric identifier for parameter/property.
        //

        public int ID { get; set; }

        //
        // Name for parameter/property.
        // 

        public string Name { get; set; }

        //
        // Small description for property/parameter.
        //

        public string Description { get; set; }

        //
        // Type name for property.
        //

        public string Type { get; set; }

        //
        // States if propery value is required or not.
        //

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public BlkParam()
        {
            ID = default(int);
            Name = default(string);
            Description = default(string);
            Type = default(string);
            Required = default(bool);
        }
    }
}
