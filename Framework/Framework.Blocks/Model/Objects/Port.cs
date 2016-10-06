// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System;

namespace Framework.Blocks.Model.Objects
{
    public class Port<TType>
    {
        //
        // PROPERTIES
        //

        public TypeOfPort Kind { get; set; }

        public TType Type { get; set; }

        //
        // CONSTRUCTORS
        //

        public Port()
        {
            Kind = TypeOfPort.UNKNOWN;
            Type = default(TType);
        }
    }
}
