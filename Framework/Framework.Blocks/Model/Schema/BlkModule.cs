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
    public class BlkModule : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<BlkFlow> Flows { get; set; }

        public ICollection<BlkBlock> Blocks { get; set; }

        public ICollection<BlkModule> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public BlkModule()
        {
            ID = default(int);
            Name = default(string);
            Flows = default(ICollection<BlkFlow>);
            Blocks = default(ICollection<BlkBlock>);
            Modules = default(ICollection<BlkModule>);
        }
    }
}
