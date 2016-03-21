// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public class Module : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Flow> Flows { get; set; }

        public ICollection<Block> Blocks { get; set; }

        //
        // CONSTRUCTORS
        //

        public Module()
        {
            ID = default(int);
            Name = default(string);
            Flows = default(ICollection<Flow>);
            Blocks = default(ICollection<Block>);
        }
    }
}
