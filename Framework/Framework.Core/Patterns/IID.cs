// ============================================================================
// Project: Framework
// Name/Class: IID
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need an identifier.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IID<T>
    {
        T ID { get; set; }
    }
}
