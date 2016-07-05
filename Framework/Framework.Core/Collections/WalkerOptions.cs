// ============================================================================
// Project: Framework
// Name/Class: WalkerOptions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Traverse options for collections.
// ============================================================================

namespace Framework.Core.Collections
{
    public class WalkerOptions
    {
        //
        // Collection walker type. These enumeration 
        // lists the types of collection traversals. Some
        // of these traversal dont make sense on some 
        // collection datatypes.
        //

        public enum TraverseType
        {
            UNDEFINED,
            DEPTH_FIRST,
            BREADTH_FIRST
        }

        //
        // When traversion collection types, some functions
        // take an initial accumulator datatype. This enumeration
        // states the behaviour for this accumulator.
        //

        public enum AccumType
        {
            UNDEFINED,
            CHAIN,
            SPREAD
        }
    }
}
