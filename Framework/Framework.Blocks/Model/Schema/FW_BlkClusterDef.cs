// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkClusterDef : 
        IOwner<int>, 
        IID<int>
    {
        //
        // PROPERTIES
        //

        public int Owner { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }
        
        public ICollection<FW_BlkModuleDef> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkClusterDef()
        {
            Owner = default(int);
            ID = default(int);
            Name = default(string);
            Modules = default(ICollection<FW_BlkModuleDef>);
        }
    }
}
