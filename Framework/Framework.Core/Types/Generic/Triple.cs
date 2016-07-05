// ============================================================================
// Project: Framework
// Name/Class: Triple
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Model a class with three values.
// ============================================================================

namespace Framework.Core.Types.Generic
{
    public class Triple<T1, T2, T3> : Pair<T1, T2>
    {
        //
        // PROPERTIES
        //

        public T3 Third { get; set; }

        //
        // CONSTRUCTORS
        //

        public Triple() : this(default(T1), default(T2), default(T3)) { }

        public Triple(T1 first, T2 second, T3 third)
            : base(first, second)
        {
            Third = third;
        }
    }
}
