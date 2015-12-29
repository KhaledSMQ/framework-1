// ============================================================================
// Project: Framework
// Name/Class: IScope
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface
{
    public interface IScope : ICommon
    {
        //
        // PROPERTIES
        //

        IHub Hub { get; }
    }
}
