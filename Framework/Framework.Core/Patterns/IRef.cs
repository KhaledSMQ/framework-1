// ============================================================================
// Project: Toolkit - Core
// Name/Class: IRef
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a reference.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IRef<T>
    {
        //
        // ID Property.
        //

        T Ref { get; set; }
    }
}
