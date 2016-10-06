// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
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
