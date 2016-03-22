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
using System.Collections.Generic;

namespace Framework.Blocks.Model.Mem
{
    public class MemFlow : MemComponent, IID<Id>
    {
        //
        // PROPERTIES
        //
        //

        public IDictionary<Id, MemConnector> Connections { get; set; }

        // CONSTRUCTORS
        //

        public MemFlow() : base()
        {
            Connections = default(IDictionary<Id, MemConnector>);
        }
    }
}
