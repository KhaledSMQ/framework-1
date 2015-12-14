// ============================================================================
// Project: Framework
// Name/Class: IAuditable
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 08/Sep/2015
// Company: Cybermap Lta.
// Description: Pattern for classes required audit info.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IAuditable<T> : ICreated<T>, IModified<T> { }
}
