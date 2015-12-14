// ============================================================================
// Project: Toolkit - Core
// Name/Class: ITimeStamp
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
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
