// ============================================================================
// Project: Framework
// Name/Class: ISet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Set interface.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface ISet<T> : System.Collections.Generic.ICollection<T>
    {
        //
        // Unions the specified other.
        //

        ISet<T> Union(ISet<T> other);

        //
        // Returns set with elements common to both.
        //

        ISet<T> Intersect(ISet<T> other);

        //
        // Either or.
        //

        ISet<T> ExclusiveOr(ISet<T> other);

        //
        // Gets the items in the set not contained in the set supplied.
        //

        ISet<T> Minus(ISet<T> other);
    }
}
