// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Eval
{
    public class Block
    {
        //
        // PROPERTIES
        //   

        public Id ID { get; set; }

        public Type Type { get; set; }

        public IDictionary<Id, Property> Properties { get; set; }

        public IDictionary<Id, Port> Ports { get; set; }

        public IDictionary<Id, Ref> Blocks { get; set; }

        public IDictionary<Id, IDictionary<Id, Connector>> Flow { get; set; }

        //
        // CONSTRUCTORS
        //

        public Block()
        {
            ID = default(Id);
            Type = default(Type);
            Properties = default(IDictionary<Id, Property>);
            Ports = default(IDictionary<Id, Port>);
            Blocks = default(IDictionary<Id, Ref>);
            Flow = default(IDictionary<Id, IDictionary<Id, Connector>>);
        }
    }
}
