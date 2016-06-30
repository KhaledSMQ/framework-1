// ============================================================================
// Project: Framework
// Name/Class: TableCol
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Table column datatype.
// ============================================================================

namespace Framework.Core.Collections.Specialized
{
    public class TableCol
    {
        // 
        // PROPERTIES
        //

        public string ID { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }

        //
        // CONSTRUCTORS
        //

        public TableCol() : this(string.Empty, string.Empty, string.Empty) { }

        public TableCol(string id, string label, string type)
        {
            ID = id;
            Label = label;
            Type = type;
        }
    }
}