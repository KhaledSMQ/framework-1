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
    public class BlockDef<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Description { get; set; }

        public PropertySet<TUser> Properties { get; set; }

        public ParamSet<TUser> In { get; set; }

        public ParamSet<TUser> Out { get; set; }

        //
        // CONSTRUCTORS
        // 

        public BlockDef() : base()
        {
            Description = default(string);
            Properties = default(PropertySet<TUser>);
            In = default(ParamSet<TUser>);
            Out = default(ParamSet<TUser>);
        }
    }
}
