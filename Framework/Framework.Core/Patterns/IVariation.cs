﻿// ============================================================================
// Project: Framework
// Name/Class: IVariation
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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
