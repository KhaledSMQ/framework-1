// ============================================================================
// Project: Framework
// Name/Class: IXsltExtensionObject
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that are Xslt extension objects.
// ============================================================================                    

namespace Framework.Core.Patterns
{
    public interface IXsltExtensionObject
    {
        string NamespaceUri { get; }
    }
}
