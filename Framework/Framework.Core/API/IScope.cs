// ============================================================================
// Project: Framework
// Name/Class: IScope
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Core.Api
{
    public interface IScope : ICommon
    {
        //
        // PROPERTIES
        //

        IHub Hub { get; }

        //
        // Method to return a new scope based on the current scope.
        // @return A new derived runtime scope.
        //

        IScope New();
    }
}
