// ============================================================================
// Project: Framework
// Name/Class: IName
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a name.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IName<T>
    {
        T Name { get; set; }
    }
}
