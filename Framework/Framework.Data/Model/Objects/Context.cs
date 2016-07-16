// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Data.Model.Objects
{
    public class Context<TUser> : ASchemaObject<TUser>
    {
        //
        // PROPERTIES
        //

        public Provider<TUser> Provider { get; set; }

        public ICollection<Entity<TUser>> Entities { get; set; }

        public ICollection<PartialModel<TUser>> Models { get; set; }

        public ICollection<Setting<TUser>> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Context()
        {
            Provider = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
