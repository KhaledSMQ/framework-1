// ============================================================================
// Project: Framework
// Name/Class: IHasName
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 01/Nov/2015

// Company: Cybermap Lta.
// Description: Pattern for items that have a name.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface IHasName
    {
        string Name { get; set; }
    }
}
