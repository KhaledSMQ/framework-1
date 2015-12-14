// ============================================================================
// Project: Framework
// Name/Class: IXRef
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
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
