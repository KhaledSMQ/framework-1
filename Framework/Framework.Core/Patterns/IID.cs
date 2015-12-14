// ============================================================================
// Project: Framework
// Name/Class: IID
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that need an identifier.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IID<T>
    {
        T ID { get; set; }
    }
}
