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
using Framework.Factory.Patterns;

namespace Framework.Factory.Runtime
{
    public static class Manager
    {
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
