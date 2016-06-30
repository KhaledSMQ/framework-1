// ============================================================================
// Project: Framework
// Name/Class: Pair
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Model a class with two values.
// ============================================================================

namespace Framework.Core.Types.Generic
{
    public class Pair<T1, T2>
    {
        //
        // PROPERTIES
        //

        public T1 First { get; set; }
        public T2 Second { get; set; }

        //
        // CONSTRUCTORS
        //

        public Pair() : this(default(T1), default(T2)) { }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }
}
