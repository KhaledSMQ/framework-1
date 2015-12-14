// ============================================================================
// Project: Framework
// Name/Class: IProvider
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Generic provider behaviour class.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface IProvider
    {
        //
        // PROPERTIES
        //

        IConfigMap Cfg { get; set; }

        //
        // API
        //

        void Init(IConfigMap config);

        void Shutdown();
    }
}
