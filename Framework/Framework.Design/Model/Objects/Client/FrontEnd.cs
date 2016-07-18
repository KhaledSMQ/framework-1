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
using System.Collections.Generic;

namespace Framework.Design.Model.Objects.Client
{
    public class FrontEnd<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Description { get; set; }

        public ICollection<Component<TUser>> Components { get; set; }

        public ICollection<Surface<TUser>> Surfaces { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FrontEnd()
        {
            Description = default(string);
            Components = default(ICollection<Component<TUser>>);
            Surfaces = default(ICollection<Surface<TUser>>);
        }
    }
}
