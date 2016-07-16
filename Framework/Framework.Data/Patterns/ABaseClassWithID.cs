// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Patterns
{
    public class ABaseClassWithID<TID, TUser> : ABaseClass<TUser>, IID<TID>
    {
        //
        // BASE
        //

        public TID ID { get; set; }  

        //
        // CONSTRUCTORS
        //

        public ABaseClassWithID()
        {
            ID = default(TID);
        }
    }
}
