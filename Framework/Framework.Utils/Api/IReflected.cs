// ============================================================================
// Project: Framework
// Name/Class: IReflected
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Api;

namespace Framework.Utils.Api
{
    public interface IReflected : ICommon
    {
        //
        // Run a specific method found in a particular service.
        // @param service The name of the service to instantiate.
        // @param method the name of the method to run.
        // @param args the list of arguments for method invocation.
        // @return Whatever the service method returns.
        //

        object Run(string service, string method, params object[] args);
    }
}
