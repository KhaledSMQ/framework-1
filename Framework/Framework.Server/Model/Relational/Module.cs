// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;

namespace Framework.Server.Model.Relational
{
    public class Module : ABaseEntityWithID<int, string>,
        IOwner<int>
    {
        //
        // PROPERTIES
        //

        public int Owner { get; set; }        

        //
        // CONSTRUCTORS
        //

        public Module()
        {
            Owner = default(int);
        }
    }
}
