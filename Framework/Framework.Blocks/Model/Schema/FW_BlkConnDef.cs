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
    public class FW_BlkConnDef : IID<int>
    {
        //
        // Numeric identifier for connection.
        //

        public int ID { get; set; }

        //
        // Name for connection. This value is intended
        // for humans and not for the actual processing
        // of blocks.
        //

        public string Name { get; set; }

        //
        // This value is the source port of the connection.
        // The source port is defined as:
        //
        //   this.IN.<NAME> 
        //
        //        this        : block where the connection is defined
        //        IN          : set of IN ports for the current block.
        //        <NAME>      : name of the port (identifier)
        //
        //   <BLOCK-REF>.OUT.<NAME> 
        //    
        //        <BLOCK-REF> : reference (value found in the Name property)
        //                      for the block reference.
        //        OUT         : set of OUT ports of the block <BLOCK-REF>
        //        <NAME>      : name for the port (identifier)
        //

        public FW_BlkPortRef Source { get; set; }

        //
        // This value is the target port of the connection,
        // The target port is defined as:
        //
        //   this.OUT.<NAME>
        //
        //        this        : block where the connection is defined
        //        OUT         : set of OUT ports for the current block.
        //        <NAME>      : name of the port (identifier)
        //
        //   <BLOCK-REF>.IN.<NAME>
        //
        //        <BLOCK-REF> : reference (value found in the Name property)
        //                      for the block reference.
        //        IN          : set of IN ports of the block <BLOCK-REF>
        //        <NAME>      : name for the port (identifier)
        //

        public FW_BlkPortRef Target { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkConnDef()
        {
            ID = default(int);
            Name = default(string);
            Source = default(FW_BlkPortRef);
            Target = default(FW_BlkPortRef);
        }
    }
}
