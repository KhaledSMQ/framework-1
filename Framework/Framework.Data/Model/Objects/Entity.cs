// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.Model.Relational;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Objects
{
    public class Entity<TUser> : ASchemaObject<TUser>
    {
        //
        // PROPERTIES
        //

        public TypeOfDataEntity Kind { get; set; }

        public string TypeName { get; set; }

        public Type Type { get { return Type.GetType(TypeName); } }

        public ICollection<Query<TUser>> Queries { get; set; }

        public ICollection<Setting<TUser>> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Entity()
        {
            Kind = TypeOfDataEntity.DATA_SET;
            TypeName = string.Empty;
            Queries = null;
            Settings = null;
        }
    }
}
