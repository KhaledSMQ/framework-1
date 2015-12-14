// ============================================================================
// Project: Framework
// Name/Class: IVariation
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that need variations.
// ============================================================================                    

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IVariation<T>
    {
        //
        // ID Property.
        //

        IEnumerable<T> Variations { get; }
    }
}
