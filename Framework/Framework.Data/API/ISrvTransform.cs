// ============================================================================
// Project: Framework
// Name/Class: ISrvTransforms
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Data.Model.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface ITransform : ICommon
    {
        //
        // CONFIGURATION OBJECT ==> SCHEMA OBJECT
        //

        FW_DataDomain Convert(DomainElement elm);
    }
}