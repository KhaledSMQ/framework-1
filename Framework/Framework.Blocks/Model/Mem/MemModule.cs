﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Mem
{
    public class MemModule : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }

        public IList<Id> Blocks { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemModule()
        {
            ID = default(Id);
            Blocks = default(IList<Id>);
        }
    }
}
