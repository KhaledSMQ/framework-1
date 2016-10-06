// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

namespace Framework.Core.Patterns
{
    public class ABaseClassWithIDAndOwner<TID, TUser, TOwner> : ABaseClassWithID<TID, TUser>
    {
        //
        // PROPERTIES
        //

        public TOwner Owner { get; set; }  

        //
        // CONSTRUCTORS
        //

        public ABaseClassWithIDAndOwner() : base()
        {
            Owner = default(TOwner);
        }
    }
}
