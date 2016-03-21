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
    public class Flow : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Block> Blocks { get; set; }

        public ICollection<Edge> Edges { get; set; }

        public ICollection<Param> In { get; set; }

        public ICollection<Param> Out { get; set; }

        public ICollection<Param> Properties { get; set; }

        //
        // CONSTRUCTORS
        //

        public Flow()
        {
            ID = default(int);
            Name = default(string);
            Blocks = default(ICollection<Block>);
            Edges = default(ICollection<Edge>);
            In = default(ICollection<Param>);
            Out = default(ICollection<Param>);
            Properties = default(ICollection<Param>);
        }
    }
}
