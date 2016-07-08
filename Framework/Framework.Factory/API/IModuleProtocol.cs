// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Factory.Model.Runtime;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public interface IModuleProtocol : ICommon
    {
        IEnumerable<Service> Services { get; }

        void LoadConfig();
    }
}
