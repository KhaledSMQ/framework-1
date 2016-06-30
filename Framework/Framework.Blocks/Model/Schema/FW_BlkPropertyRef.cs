// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkPropertyRef : IID<int>
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

        public string Value { get; set; }     

        //
        // CONSTRUCTORS
        //

        public FW_BlkPropertyRef()
        {
            ID = default(int);
            Name = default(string);
            Value = default(string);          
        }
    }
}
