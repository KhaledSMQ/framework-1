// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkBlockDef
    {
        //
        // Numeric identifier for block definition.
        //

        public int ID { get; set; }
     
        //
        // Simple name for block.
        // Used for build the complete/unique identifier
        // for block definition.
        //

        public string Name { get; set; }

        //
        // Description for block definition.
        //

        public string Description { get; set; }

        //
        // Type of the block implementation.
        // This is the native service that implements
        // the block. It is what ables the block to execute.
        // It should be a full type definition.
        //

        public string TypeName { get; set; }

        //
        // Set of block port definitions.
        // This set includes all input and output ports 
        // for the block. Also some control properties,
        // like:
        //    - Cardinallity of input ports.
        //    - Cardinallity of output ports.
        //

        public ICollection<FW_BlkPortDef> Ports { get; set; }

        //
        // Set of block property definitions.
        //

        public ICollection<FW_BlkPropertyDef> Properties { get; set; }

        //
        // Block pipeline definition.
        // Blocks are composed by inner block references,
        // i.e. instances of other block definitions a a 
        // set of connections, linking the block references.
        //

        public ICollection<FW_BlkBlockRef> Blocks { get; set; }

        public ICollection<FW_BlkConnDef> Connections { get; set; }

        //
        // CONSTRUCTORS 
        //

        public FW_BlkBlockDef()
        {
            ID = default(int);
            Name = default(string);
            Description = default(string);
            Ports = default(ICollection<FW_BlkPortDef>);
            Properties = default(ICollection<FW_BlkPropertyDef>);
            Blocks = default(ICollection<FW_BlkBlockRef>);
            Connections = default(ICollection<FW_BlkConnDef>);
        }
    }
}
