// ============================================================================
// Project: Framework
// Name/Class: IName
// Author: João Carreiro (joao.carreiro@cybermap.pt)
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
