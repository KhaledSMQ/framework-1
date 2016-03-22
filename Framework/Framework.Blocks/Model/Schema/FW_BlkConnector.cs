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
    public class FW_BlkConnector : IID<int>
    {
        //
        // Numeric identifier for connection.
        //

        public int ID { get; set; }

        //
        // Property name from the source block.
        //

        public string Source { get; set; }

        //
        // Property name for the target block.
        //

        public string Target { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkConnector()
        {
            ID = default(int);
            Source = default(string);
            Target = default(string);
        }
    }
}
