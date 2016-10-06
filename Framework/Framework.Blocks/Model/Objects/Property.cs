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
using System;

namespace Framework.Blocks.Model.Objects
{
    public class Property<TType> : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }     

        public TType Type { get; set; }

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public Property()
        {
            ID = default(Id);
            Type = default(TType);
            Required = default(bool);
        }
    }
}
