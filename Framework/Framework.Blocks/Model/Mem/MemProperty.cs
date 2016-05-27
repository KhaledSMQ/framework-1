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

namespace Framework.Blocks.Model.Mem
{
    public class MemProperty : IID<Id>
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

        public MemProperty()
        {
            ID = default(Id);
            Type = default(Type);
            Required = default(bool);
        }
    }
}
