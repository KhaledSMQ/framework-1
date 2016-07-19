// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Objects
{
    public class BlockUse 
    {
        //
        // PROPERTIES
        //
     
        public Id Def { get; set; }

        public IDictionary<Id, object> Properties { get; set; }
      
        //
        // CONSTRUCTORS 
        //

        public BlockUse()
        {
            Def = default(Id);
            Properties = default(IDictionary<Id, object>);
        }
    }
}
