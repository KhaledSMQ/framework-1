// ============================================================================
// Project: Toolkit - Core
// Name/Class: ITimeStamp
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a time stanp.
// ============================================================================                    

using System;

namespace Framework.Core.Patterns
{
    public interface ITimeStamp
    {
        DateTime TimeStamp { get; set; }
    }
}
