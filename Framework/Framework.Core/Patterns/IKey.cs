// ============================================================================
// Project: Framework
// Name/Class: IKey
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a key.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IKey<T>
    {
        T Key { get; set; }
    }
}
