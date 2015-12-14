// ============================================================================
// Project: Framework
// Name/Class: IXsltExtensionObject
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Pattern for classes that are Xslt extension objects.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IXsltExtensionObject
    {
        string NamespaceUri { get; }
    }
}
