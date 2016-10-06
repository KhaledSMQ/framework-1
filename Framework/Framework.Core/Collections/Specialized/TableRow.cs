// ============================================================================
// Project: Framework
// Name/Class: TableRow
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Table row datatype.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Core.Collections.Specialized
{
    public class TableRow : List<object>, IList<object>
    {
        //
        // CONSTRUCTORS
        //

        public TableRow() : base() { }

        public TableRow(IEnumerable<object> val)
            : this()
        {
            AddRange(val);
        }

        //
        // STANDARD METHODS
        //

        public override string ToString()
        {
            return this.UnparseToString("[", "]", ", ");
        }
    }
}
