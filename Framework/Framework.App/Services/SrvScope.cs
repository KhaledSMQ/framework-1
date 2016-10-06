// ============================================================================
// Project: Framework
// Name/Class: SrvScope
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Scope service implementation..
// ============================================================================

using Framework.App.Runtime;
using Framework.Core.Api;
using Framework.Core.Patterns;

namespace Framework.App.Services
{
    public class SrvScope : ACommon, IScope
    {
        //
        // PROPERTIES
        //

        public IHub Hub
        {
            get { return Manager.Hub; }
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
