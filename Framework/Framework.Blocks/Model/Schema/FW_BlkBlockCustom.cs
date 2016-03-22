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
    //
    // Block: CUSTOM
    // These types of blocks are composed of inner
    // block references inter-connected. They are
    // defined by user.
    //

    public class FW_BlkBlockCustom : FW_BlkABlock
    {
        //
        // Wiring of internal block references.
        //

        public ICollection<FW_BlkConnector> Connections { get; set; }

        //
        // CONSTRUCTORS 
        //

        public FW_BlkBlockCustom() : base()
        {
            Connections = default(ICollection<FW_BlkConnector>);
        }
    }
}
