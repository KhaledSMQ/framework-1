﻿// ============================================================================
// Project: Framework  Core
// Name/Class: IDescription
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a description.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IDescription<T>
    {
        T Description { get; set; }
    }
}
