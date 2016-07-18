// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.API;
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
