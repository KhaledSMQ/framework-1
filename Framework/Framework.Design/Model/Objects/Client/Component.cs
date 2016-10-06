// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 18/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Core.Patterns;

namespace Framework.Design.Model.Objects.Client
{
    public class Block<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public Id Type { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Block() : base()
        {
            Type = default(Id);
        }
    }
}
