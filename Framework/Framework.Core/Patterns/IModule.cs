// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;

namespace Framework.Core.Patterns
{
    public interface IModule
    {
        System.Collections.Generic.IEnumerable<Service> Services { get; }

        void LoadConfig();
    }
}
