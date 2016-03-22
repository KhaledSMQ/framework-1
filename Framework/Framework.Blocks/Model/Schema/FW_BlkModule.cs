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
    public class FW_BlkModule : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<FW_BlkFlow> Flows { get; set; }

        public ICollection<FW_BlkBlock> Blocks { get; set; }

        public ICollection<FW_BlkModule> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkModule()
        {
            ID = default(int);
            Name = default(string);
            Flows = default(ICollection<FW_BlkFlow>);
            Blocks = default(ICollection<FW_BlkBlock>);
            Modules = default(ICollection<FW_BlkModule>);
        }
    }
}
