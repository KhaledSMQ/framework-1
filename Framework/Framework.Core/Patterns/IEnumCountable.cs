// ============================================================================
// Project: Framework  Core
// Name/Class: IEnumCountable
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================                    

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IEnumCountable<T> : IEnumerator<T>
    {
        //
        // Indicates if the enumerator is empty ( it has 0 items ).
        //

        bool IsEmpty { get; }

        //
        // Indicate if current item is first.
        //

        bool IsFirst();

        //
        // Indicate if current item is last.
        //

        bool IsLast();

        //
        // Get the index of the current item.
        //

        int CurrentIndex { get; }

        //
        // Get the total number of items.
        //

        int Count { get; }
    }
}
