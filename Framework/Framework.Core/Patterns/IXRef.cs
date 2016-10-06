// ============================================================================
// Project: Framework
// Name/Class: IXRef
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that have namespace and name properties.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IXRef
    {
        //
        // PROPERTIES
        //

        string Namespace { get; set; }
        string Name { get; set; }
    }
}
