// ============================================================================
// Project: Framework
// Name/Class: Scope
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime context implementation.
// ============================================================================

using System;
using Framework.Factory.API.Interface;
using Framework.Factory.Patterns;

namespace Framework.Factory.Runtime
{
    public class SrvScope : ACommon, IScope
    {
        //
        // PROPERTIES
        //

        public IHub Hub
        {
            get { return Factory.Runtime.Manager.Hub; }
        }

        //
        // CONSTRUCTORS
        //

        public SrvScope()
        {           
        }
    }
}
