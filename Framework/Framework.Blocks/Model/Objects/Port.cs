// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System;

namespace Framework.Blocks.Model.Objects
{
    public class Port
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

        public Port()
        {
            Kind = TypeOfPort.UNKNOWN;
            Type = default(Type);
            Required = default(bool);
        }
    }
}
