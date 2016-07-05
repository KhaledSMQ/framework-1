﻿// ============================================================================
// Project: Framework
// Name/Class: IAuditable
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 08/Sep/2015
// Company: Coop4Creativity
// Description: Pattern for classes required audit info.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IAuditable<T> : ICreated<T>, IModified<T> { }
}
