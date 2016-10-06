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
    public class Block<TValue> : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }

        public Id Type { get; set; }

        public IDictionary<Id, TValue> Args { get; set; }

        //
        // CONSTRUCTORS 
        //

        public Block()
        {
            ID = default(Id);
            Type = default(Id);
            Args = default(IDictionary<Id, TValue>);
        }
    }
}
