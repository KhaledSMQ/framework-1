// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkFlow : IComponent
    {
        //
        // Unique identifier for flow.
        //

        public int ID { get; set; }

        //
        // Name for flow.
        //

        public string Name { get; set; }

        //
        // Definition of input parameters.
        //

        public ICollection<FW_BlkParam> In { get; set; }

        //
        // Definition of output values.
        //

        public ICollection<FW_BlkParam> Out { get; set; }

        //
        // Properties of component.
        // 

        public ICollection<FW_BlkParam> Properties { get; set; }

        //
        // List of block references 
        //

        public ICollection<FW_BlkEdge> Edges { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkFlow()
        {
            ID = default(int);
            Name = default(string);
            Edges = default(ICollection<FW_BlkEdge>);
            In = default(ICollection<FW_BlkParam>);
            Out = default(ICollection<FW_BlkParam>);
            Properties = default(ICollection<FW_BlkParam>);
        }
    }
}
