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
