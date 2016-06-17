// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Models.Model.Import
{
    public class Entity :
        IName<string>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public Value<string> Display { get; set; }

        public Value<string> Description { get; set; }

        public IDictionary<string, Property> Properties { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Entity()
        {
            Name = default(string);
            Description = default(Value<string>);
            Properties = null;
        }
    }
}
