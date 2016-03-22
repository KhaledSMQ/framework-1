// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Runtime
{
    public class Block
    {
        public Input Input { get; set; }

        public Output Output { get; set; }

        public IDictionary<Id, object> Blocks { get; set; }

        public IDictionary<Id, object> Connections { get; set; }
    }
}
