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
    public class Provider<TUser> : ASchemaObject<TUser>
    {
        //
        // PROPERTIES
        //

        public string TypeName { get; set; }

        public ICollection<Setting<TUser>> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Provider()
        {          
            TypeName = string.Empty;
            Settings = null;
        }
    }
}
