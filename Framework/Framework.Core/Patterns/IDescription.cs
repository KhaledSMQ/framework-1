// ============================================================================
// Project: Framework  Core
// Name/Class: IDescription
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that need a description.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IDescription<T>
    {
        T Description { get; set; }
    }
}
