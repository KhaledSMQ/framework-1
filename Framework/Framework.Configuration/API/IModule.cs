// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Configuration.API
{
    public interface IModule : ICommon
    {
        void LoadConfig();
    }
}
