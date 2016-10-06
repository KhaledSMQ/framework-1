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
using System.Collections.Generic;

namespace Framework.Design.Model.Objects.Client
{
    public class App<TUser> : ABaseClassWithID<Id, TUser>
    {
        //
        // PROPERTIES
        //

        public string Description { get; set; }

        public ICollection<ComponentDef<TUser>> Components { get; set; }

        public ICollection<BlockDef<TUser>> Blocks { get; set; }

        public ICollection<Fragment<TUser>> Fragments { get; set; }

        //
        // CONSTRUCTORS
        // 

        public App() : base()
        {
            Description = default(string);
            Components = default(ICollection<ComponentDef<TUser>>);
            Blocks = default(ICollection<BlockDef<TUser>>);
            Fragments = default(ICollection<Fragment<TUser>>);
        }
    }
}
