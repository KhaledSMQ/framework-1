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
using System.Collections.Generic;

namespace Framework.Blocks.Model.Mem
{
    public class MemCluster : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }

        public IList<Id> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public MemCluster()
        {
            ID = default(Id);
            Modules = default(IList<Id>);
        }
    }
}
