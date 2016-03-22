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
    public class FW_BlkBlockCustom : FW_BlkABlock
    {
        //
        // Block internal wiring.
        // For CUSTOM blocks.
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
