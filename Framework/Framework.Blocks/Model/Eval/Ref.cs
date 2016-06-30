// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Eval
{
    public class Ref
    {
        //
        // PROPERTIES
        //   

        public Id Def { get; set; }

        public IDictionary<Id, Property> Properties { get; set; }     

        //
        // CONSTRUCTORS
        //

        public Ref()
        {
            Def = default(Id);
            Properties = default(IDictionary<Id, Property>);         
        }
    }
}
