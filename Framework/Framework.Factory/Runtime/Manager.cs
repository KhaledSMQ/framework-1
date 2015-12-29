// ============================================================================
// Project: Framework
// Name/Class: Context
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime context implementation.
// ============================================================================

using Framework.Factory.API.Default;
using Framework.Factory.API.Interface;
using Framework.Factory.Model;
using Framework.Factory.Patterns;

namespace Framework.Factory.Runtime
{
    public static class Manager
    {
        //
        // PROPERTIES
        //

        public static Service HubConfig { get; private set; }

        public static Service ScopeConfig { get; private set; }

        public static IHub Hub { get; private set; }

        //
        // CONSTRUCTORS
        //

        static Manager()
        {
        }

        public static IScope Get()
        {
            return null;
        }
    }
}
