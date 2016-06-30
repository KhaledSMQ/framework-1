// ============================================================================
// Project: Framework
// Name/Class: IObjectMap
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for mappings objects.
// ============================================================================ 

using Framework.Core.Types.Generic;
using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IObjectMap<T>
    {
        //
        // Register a list of type mappings. This method will traverse a list of type mapping
        // and insert them one by one. The update flag is applied to each insertion.
        //

        void Register(IList<Triple<string, string, T>> list, bool update = true);

        //
        // Register a new type mapping in this table. This method will register a new
        // type mapping, in case the update flag is set to true, then if the mapping 
        // already exists, it is replaced. If this flag is set to false, then no replacement
        // is made and an exception is thrown.
        //

        void Register(string namespc, string name, T value, bool update = true);

        //
        // Unregister the type mapping from table. This method will try to
        // unload the registered type mapping from this table. If the mapping
        // does not exist and the quit option is set to false, then this will throw
        // an exception.
        //

        void Unregister(string namespc, string name, bool quiet = true);

        //
        // Get a required mapping from this map structure. If mapping is not 
        // found, then throw an exception.
        //

        T GetRequired(string namespc, string name);
    }
}
