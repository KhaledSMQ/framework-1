// ============================================================================
// Project: Framework
// Name/Class: IScope
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
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

        IContainer Hub { get; }

        //
        // Method to return a new scope based on the current scope.
        // @return A new derived runtime scope.
        //

        IScope New();
    }
}
