// ============================================================================
// Project: Framework
// Name/Class: SrvScope
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Scope service implementation..
// ============================================================================

using Framework.App.Runtime;
using Framework.Core.Api;
using Framework.Core.Patterns;

namespace Framework.App.Services
{
    public class Scope : ACommon, IScope
    {
        //
        // PROPERTIES
        //

        public IContainer Hub
        {
            get { return Manager.Container; }
        }

        //
        // Mrthod to return a new scope based on 
        // the current scope.
        // @return A new derived runtime scope.
        //

        public IScope New()
        {
            return this;
        }
    }
}
