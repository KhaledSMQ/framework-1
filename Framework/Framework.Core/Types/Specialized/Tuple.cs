// ============================================================================
// Project: Framework
// Name/Class: Tuple
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Tuple implementation.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Core.Types.Specialized
{
    public class Tuple : List<object>, IList<object>
    {
        //
        // CONSTRUCTORS
        //

        public Tuple() : base() { }

        public Tuple(IEnumerable<object> args) : base(args) { }

        //
        // TO-STRING
        // String implementation for object instance.
        //

        public override string ToString()
        {
            return this.UnparseToString("(", ")", ", ");
        }

        //
        // Static method for tuple constuction.
        // @param args A variable list of objects for the tuple.
        //

        public static Tuple Set(params object[] args)
        {
            return new Tuple(args);
        }
    }
}
