// ============================================================================
// Project: Framework
// Name/Class: IKey
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that need a key.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IKey<T>
    {
        T Key { get; set; }
    }
}
