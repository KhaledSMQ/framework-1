// ============================================================================
// Project: Framework
// Name/Class: ICommon
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base service contract.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Core.Api
{
    public interface ICommon : IProvider
    {
        //
        // PROPERTIES
        //

        IScope Scope { get; set; }
    }
}
