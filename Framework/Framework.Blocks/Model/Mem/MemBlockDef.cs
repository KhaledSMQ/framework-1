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
using System;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Mem
{
    public class MemBlockDef : IID<Id>
    {
        //
        // PROPERTIES
        //   

        public Id ID { get; set; }

        public Type Type { get; set; }

        public IDictionary<Id, MemProperty> Properties { get; set; }

        public IDictionary<Id, MemPort> Ports { get; set; }

        public IDictionary<Id, MemBlockRef> Blocks { get; set; }

        public IDictionary<Id, IDictionary<Id, MemConnector>> Connections { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemBlockDef()
        {
            ID = default(Id);
            Type = default(Type);
            Properties = default(IDictionary<Id, MemProperty>);
            Ports = default(IDictionary<Id, MemPort>);
            Blocks = default(IDictionary<Id, MemBlockRef>);
            Connections = default(IDictionary<Id, IDictionary<Id, MemConnector>>);
        }
    }
}
