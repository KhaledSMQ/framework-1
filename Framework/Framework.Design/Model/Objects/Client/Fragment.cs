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
    public class Fragment<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Description { get; set; }

        public ParamSet<TUser> Params { get; set; }

        public View<TUser> View { get; set; }

        public Controller<TUser> Controller { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Fragment()
        {
            Description = default(string);
            Params = default(ParamSet<TUser>);
            View = default(View<TUser>);
            Controller = default(Controller<TUser>);
        }
    }
}
