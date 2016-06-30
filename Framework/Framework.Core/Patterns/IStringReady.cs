// ============================================================================
// Project: Framework
// Name/Class: IStringReady
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that implement parse and unparse from strs 
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IStringReady
    {
        //
        // Parse from a string value element the item specification. This method will 
        // take a string and parse it, building the item properties. This
        // should clear all current properties, if they exist.
        //

        void ParseFromString(string val);

        //
        // Unparse the item to a string value. This method will
        // generate a string value from this items properties.
        //

        string UnparseToString();
    }
}
