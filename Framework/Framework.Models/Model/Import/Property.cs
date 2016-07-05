// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Models.Model.Import
{
    public class Property :
        IName<string>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public Value<string> Display { get; set; }

        public Value<string> Description { get; set; }

        public uint Order { get; set; }

        public bool IsLocalizable { get; set; }

        public bool IsNullable { get; set; }

        public bool IsPrimaryKey { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Property()
        {
            Name = default(string);
            Display = default(Value<string>);
            Description = default(Value<string>);
            Order = default(uint);
            IsLocalizable = default(bool);
            IsNullable = default(bool);
            IsPrimaryKey = default(bool);
        }
    }
}
