// ============================================================================
// Project: Framework
// Name/Class: IReflected
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface
{
    public interface IReflected : ICommon
    {
        //
        // Run a apseicifc method found in a
        // particular service.
        // @param service The name of the service to instantiate.
        // @param method the name of the method to run.
        // @param args the list of arguments for method invocation.
        // @return Whatever the service method returns.
        //

        object Run(string service, string method, params object[] args);
    }
}
