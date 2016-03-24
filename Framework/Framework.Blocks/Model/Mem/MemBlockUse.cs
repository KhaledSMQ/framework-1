// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Mem
{
    public class MemBlockUse 
    {
        //
        // PROPERTIES
        //
     
        public Id Def { get; set; }

        public IDictionary<Id, object> Properties { get; set; }
      
        //
        // CONSTRUCTORS 
        //

        public MemBlockUse()
        {
            Def = default(Id);
            Properties = default(IDictionary<Id, object>);
        }
    }
}
