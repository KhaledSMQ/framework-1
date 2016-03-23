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
    public class MemBlockTemplate : IID<Id>
    {
        //
        // PROPERTIES
        //   

        public Id ID { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public IDictionary<Id, MemProperty> Properties { get; set; }

        public IDictionary<Id, MemPort> Ports { get; set; }

        public IDictionary<Id, MemBlock> Blocks { get; set; }

        public IDictionary<Id, IList<MemConnector>> Connections { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemBlockTemplate()
        {
            ID = default(Id);
            Description = default(string);
            TypeName = default(string);
            Properties = default(IDictionary<Id, MemProperty>);
            Ports = default(IDictionary<Id, MemPort>);
            Blocks = default(IDictionary<Id, MemBlock>);
            Connections = default(IDictionary<Id, IList<MemConnector>>);
        }
    }
}
