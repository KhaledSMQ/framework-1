// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Api;
using System.CodeDom;

namespace Framework.Code.Api
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
