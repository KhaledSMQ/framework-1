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
    public class Scope : IScope
    {
        //
        // PROPERTIES
        //

        public IHub Hub { get; set; }

        public IStore Store { get; set; }

        //
        // CONSTRUCTORS
        //

        public Scope()
        {
            Hub = new Hub();
            Hub.Init(null);
        }
    }
}
