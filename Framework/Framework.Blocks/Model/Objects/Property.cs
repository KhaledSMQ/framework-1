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

namespace Framework.Blocks.Model.Objects
{
    public class Property : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }     

        public Type Type { get; set; }

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public Property()
        {
            ID = default(Id);
            Type = default(Type);
            Required = default(bool);
        }
    }
}
