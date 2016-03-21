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
    public class BlkDomain : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }
        
        public ICollection<BlkModule> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public BlkDomain()
        {
            ID = default(int);
            Name = default(string);
            Modules = default(ICollection<BlkModule>);
        }
    }
}
