// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Code.Model;
using Framework.Factory.Patterns;
using System.CodeDom;

namespace Framework.Code.API
{
    public interface IClassGenerator : ICommon
    {
        CodeCompileUnit GenerateSimpleClass(SimpleClass classSpec);
    }
}
