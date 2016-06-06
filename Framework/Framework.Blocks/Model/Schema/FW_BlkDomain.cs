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
    public class FW_BlkDomain : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<FW_BlkModuleDef> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkDomain()
        {
            ID = default(int);
            Name = default(string);
            Modules = default(ICollection<FW_BlkModuleDef>);
        }
    }
}
