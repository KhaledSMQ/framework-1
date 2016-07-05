// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Blocks.API
{
    public interface ICfg : ICommon
    {
        void Load();
    }
}
