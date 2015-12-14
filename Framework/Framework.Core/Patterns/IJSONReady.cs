// ============================================================================
// Project: Framework
// Name/Class: IJSONReady
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that parse and unparse JSON.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IJSONReady
    {
        //
        // Parse a JSON specification from a string and build this item
        // structure and properties.
        //

        void ParseFromJSON(string json);

        //
        // Unparse the item to a JSON specification. Method to build a 
        // specific JSON representation for the item.
        //

        void UnparseToJSON();
    }
}
