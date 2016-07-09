// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

namespace Framework.Factory.Patterns
{
    public interface IModule : ICommon
    {
        System.Collections.Generic.IEnumerable<Model.Runtime.Service> Services { get; }

        void LoadConfig();
    }
}
