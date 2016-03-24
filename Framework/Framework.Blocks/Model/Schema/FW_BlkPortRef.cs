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
    public class FW_BlkPortRef : IID<int>
    {
        //
        // Numeric identifier for parameter/property.
        //

        public int ID { get; set; }

        //
        // Identifier for block referecne.
        // If value is null then it means that the
        // port references the block that we are defining.
        //

        public string Block { get; set; }  

        //
        // Name for port.
        // 

        public string Name { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkPortRef()
        {
            ID = default(int);
            Block = default(string);
            Name = default(string);
        }
    }
}
