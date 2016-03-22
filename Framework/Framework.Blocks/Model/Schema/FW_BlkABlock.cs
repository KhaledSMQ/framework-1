// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public abstract class FW_BlkABlock : IComponent
    {
        //
        // Numeric identifier for block.
        //

        public int ID { get; set; }
     
        //
        // Name for block.
        //

        public string Name { get; set; }

        //
        // Definition for block input parameters.
        //

        public ICollection<FW_BlkParam> In { get; set; }

        //
        // Definition for block output parameters.
        //

        public ICollection<FW_BlkParam> Out { get; set; }

        //
        // Configuration properties for block.
        //

        public ICollection<FW_BlkParam> Properties { get; set; }        

        //
        // CONSTRUCTORS 
        //

        public FW_BlkABlock()
        {
            ID = -1;
            Name = default(string);
            In = default(ICollection<FW_BlkParam>);
            Out = default(ICollection<FW_BlkParam>);
            Properties = default(ICollection<FW_BlkParam>);
        }
    }
}
