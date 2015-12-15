// ============================================================================
// Project: Framework
// Name/Class: IProviderDataModel
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data partial model.
// ============================================================================

using Framework.Core.Patterns;
using System;

namespace Framework.Data.Patterns
{
    public interface IProviderDataModel : IProvider
    {
        //
        // MODEL-BUILD-HANDLER
        //

        void OnModelCreate(object context, IConfigMap config);
    }
}
