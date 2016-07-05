﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkPropertyDef : IID<int>
    {
        //
        // Identifier for property.
        //

        public int ID { get; set; }

        //
        // Name for property.
        // 

        public string Name { get; set; }

        //
        // Description for property.
        //

        public string Description { get; set; }

        //
        // Type for property.
        //

        public string TypeName { get; set; }

        //
        // Is this property required?
        //

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkPropertyDef()
        {
            ID = default(int);
            Name = default(string);
            Description = default(string);
            TypeName = default(string);
            Required = default(bool);
        }
    }
}
