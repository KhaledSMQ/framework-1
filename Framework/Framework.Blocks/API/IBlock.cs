// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Runtime;
using Framework.Factory.Patterns;

namespace Framework.Blocks.API
{
    public interface IBlock : ICommon
    {
        //
        // Run a block definition using the native 
        // execution for the specified block type.
        //

        Output Eval(Block block, Context ctx);
    }
}
