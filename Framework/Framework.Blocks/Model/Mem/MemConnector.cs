// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;

namespace Framework.Blocks.Model.Mem
{
    public class MemConnector
    {
        //
        // PROPERTIES
        //

        public Id Name { get; set; }

        public Id Target { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemConnector()
        {
            Name = default(Id);
            Target = default(Id);
        }
    }
}
