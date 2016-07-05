// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Blocks.Model.Schema;
using System;

namespace Framework.Blocks.Model.Mem
{
    public class MemPort
    {
        //
        // PROPERTIES
        //

        public TypeOfPort Kind { get; set; }

        public Type Type { get; set; }

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemPort()
        {
            Kind = TypeOfPort.UNKNOWN;
            Type = default(Type);
            Required = default(bool);
        }
    }
}
