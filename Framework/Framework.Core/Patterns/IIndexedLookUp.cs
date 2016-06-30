// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Interface for storing a collection of objects of type T,
//              such that the objects can be looked up by either the
//              id of the object T or by creating a distinct name for the 
//              object based on it's hashcode.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface IIndexedLookUp<TKey, T> where T : IIndexedComponent<TKey>
    {
        //
        // Gets an object based on its id.
        //

        T this[TKey id] { get; }

        //
        // Gets an object based on its name.
        //

        T this[string name] { get; }

        //
        // Gets the number of items stored in the collection.
        //

        int Count { get; }
    }
}
