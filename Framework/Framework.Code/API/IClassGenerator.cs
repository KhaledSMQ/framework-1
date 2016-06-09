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
    public interface IClassGenerator : ICommon
    {
        CodeCompileUnit GenerateSimpleClass(SimpleClass classSpec);
    }
}
