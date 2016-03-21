// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class BlkEdge : IID<int>
    {
        //
        // Numeric identifier for connection/edge.
        //

        public int ID { get; set; }

        //
        // Name/identifier for source block.
        //

        public string Source { get; set; }

        //
        // Name/identifier for target block.
        //

        public string Target { get; set; }

        //
        // List of connections between the two blocks.
        //

        public ICollection<BlkConnector> Connections { get; set; }

        //
        // CONSTRUCTOR
        //

        public BlkEdge()
        {
            ID = default(int);
            Source = default(string);
            Target = default(string);
            Connections = default(ICollection<BlkConnector>);
        }
    }
}
