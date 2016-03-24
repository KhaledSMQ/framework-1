// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkBlockRef
    {
        //
        // Numeric identifier for block reference.
        //

        public int ID { get; set; }
     
        //
        // Simple name for block reference (i.e. variable).
        // This value is used as the identifier for connections
        // inside a block definition.
        //

        public string Name { get; set; }

        //
        // Complete unique definition reference for this block.
        // This property has the value of the unique identifier
        // of the associated block definition.
        //

        public string Def { get; set; }

        //
        // Specific properties for the block instance.
        //

        public ICollection<FW_BlkPropertyRef> Properties { get; set; }
      
        //
        // CONSTRUCTORS 
        //

        public FW_BlkBlockRef()
        {
            ID = -1;
            Name = default(string);
            Def = default(string);
            Properties = default(ICollection<FW_BlkPropertyRef>);           
        }
    }
}
