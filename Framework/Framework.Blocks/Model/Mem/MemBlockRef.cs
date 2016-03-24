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
    public class MemBlockRef 
    {
        //
        // PROPERTIES
        //
     
        public Id Def { get; set; }

        public IDictionary<Id, object> Properties { get; set; }
      
        //
        // CONSTRUCTORS 
        //

        public MemBlockRef()
        {
            Def = default(Id);
            Properties = default(IDictionary<Id, object>);
        }
    }
}
