// ============================================================================
// Project: Framework
// Name/Class: IType
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that need a type reference name.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface ITypeName<T>
    {
        T TypeName { get; set; }
    }
}
