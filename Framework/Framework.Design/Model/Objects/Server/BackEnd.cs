// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 18/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;

namespace Framework.Design.Model.Objects.Client
{
    public class BackEnd<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        //
        // CONSTRUCTORS
        // 

        public BackEnd()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
