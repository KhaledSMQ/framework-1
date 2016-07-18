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
    public class Component<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Description { get; set; }

        public ParamSet<TUser> Properties { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Component()
        {
            Description = default(string);
            Properties = default(ParamSet<TUser>);
        }
    }
}
