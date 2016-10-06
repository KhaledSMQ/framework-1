// ============================================================================
// Project: Framework
// Name/Class: Table
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Table datatype.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Core.Collections.Specialized
{
    public class Table
    {
        //
        // PROPERTIES
        //

        public IList<TableCol> Header { get; set; }
        public IList<TableRow> Rows { get; set; }

        //
        // CONSTRUCTORS
        //

        public Table() : this(new List<TableCol>(), new List<TableRow>()) { }

        public Table(IList<TableCol> header, IList<TableRow> rows)
        {
            Header = header;
            Rows = rows;
        }

        //
        // STANDARD METHODS
        //

        public override string ToString()
        {
            return "[header:" + Header.UnparseToString("[", "]", ", ") + " rows:" + Rows.UnparseToString("[", "]", ", ") + "]";
        }
    }
}
