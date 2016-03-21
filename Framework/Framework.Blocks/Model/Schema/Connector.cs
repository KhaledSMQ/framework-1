// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class Connector : IID<int>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        //
        // CONSTRUCTORS
        //

        public Connector()
        {
            ID = default(int);
            Source = default(string);
            Target = default(string);
        }
    }
}
