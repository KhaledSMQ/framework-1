// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Objects
{
    public class BlockDef : IID<Id>
    {
        //
        // PROPERTIES
        //   

        public Id ID { get; set; }

        public Id Base { get; set; }

        public IDictionary<Id, Property> Properties { get; set; }

        public IDictionary<Id, Port> Ports { get; set; }

        public IDictionary<Id, BlockUse> Blocks { get; set; }

        public IDictionary<Id, IDictionary<Id, Connector>> Flow { get; set; }

        //
        // CONSTRUCTORS
        //

        public BlockDef()
        {
            ID = default(Id);
            Base = default(Id);
            Properties = default(IDictionary<Id, Property>);
            Ports = default(IDictionary<Id, Port>);
            Blocks = default(IDictionary<Id, BlockUse>);
            Flow = default(IDictionary<Id, IDictionary<Id, Connector>>);
        }
    }
}
