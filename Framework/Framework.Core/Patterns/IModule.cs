// ============================================================================
// Project: Framework
// Name/Class: ICfg
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IModule
    {
        //
        // Full qualified name for module.
        //

        string Name { get; }

        //
        // Complete list of available services.
        //

        IEnumerable<Service> Services { get; }

        //
        // Method for loading the module configuration settings.
        //

        void LoadConfig();
    }
}
