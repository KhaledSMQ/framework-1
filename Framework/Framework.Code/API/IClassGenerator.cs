// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Code.Model;
using Framework.Core.Api;
using System.CodeDom;

namespace Framework.Code.Api
{
    public interface IClassGenerator : ICommon
    {
        CodeCompileUnit GenerateSimpleClass(SimpleClass classSpec);
    }
}
