// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Code.Model;
using Framework.Factory.Patterns;
using System.CodeDom;

namespace Framework.Code.API
{
    public enum CodeProvider
    {
        CSHARP,
        VISUAL_BASIC,
        JSCRIPT
    }

    public interface ICompiler : ICommon
    {

        void GenerateSourceCode(CodeProvider provider, string filePath, CodeCompileUnit unit);
    }
}
