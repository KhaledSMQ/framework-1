// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Objects
{
    public class BlockDef<TType, TValue> : IID<Id>
    {
        //
        // PROPERTIES
        //   

        public Id ID { get; set; }

        public Id Base { get; set; }

        public IDictionary<Id, Property<TType>> Properties { get; set; }

        public IDictionary<Id, Port<TType>> Ports { get; set; }

        public IDictionary<Id, Block<TValue>> Blocks { get; set; }

        public IDictionary<Id, IDictionary<Id, Connector>> Flow { get; set; }

        //
        // CONSTRUCTORS
        //

        public BlockDef()
        {
            ID = default(Id);
            Base = default(Id);
            Properties = default(IDictionary<Id, Property<TType>>);
            Ports = default(IDictionary<Id, Port<TType>>);
            Blocks = default(IDictionary<Id, Block<TValue>>);
            Flow = default(IDictionary<Id, IDictionary<Id, Connector>>);
        }
    }
}
