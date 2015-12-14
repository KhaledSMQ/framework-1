// ============================================================================
// Project: Framework
// Name/Class: IScope
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.API.Interface;

namespace Framework.Factory.Patterns
{
    public interface IScope
    {
        //
        // PROPERTIES
        //

        IHub Hub { get; set; }

        IStore Store { get; set; }
    }
}
