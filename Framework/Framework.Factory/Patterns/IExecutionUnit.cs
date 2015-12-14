// ============================================================================
// Project: Framework
// Name/Class: IExecutionUnit
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Execution unit pattern.
// ============================================================================

using Framework.Core.Types.Specialized;

namespace Framework.Factory.Patterns
{
    public interface IExecutionUnit : ICommon
    {
        Tuple Execute(Tuple input);
    }
}
