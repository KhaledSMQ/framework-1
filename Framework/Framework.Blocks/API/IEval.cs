// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 21/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;

namespace Framework.Blocks.API
{
    public interface IEval : ICommon
    {
        //
        // EVALUATE
        // Evaluate a block based on its unique id.
        //

        object Eval(string blockID, object args);

        object Eval(Id blockID, object args);

        //
        // EVALUATE
        // Different processing stages.
        //

        object Eval_StageEvalBlock(string blockID, object args);

        object Eval_StageEvalBlock(Id blockID, object args);
    }
}
