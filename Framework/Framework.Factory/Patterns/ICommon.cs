﻿// ============================================================================
// Project: Framework
// Name/Class: ICommon
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service contract.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Factory.API.Interface;

namespace Framework.Factory.Patterns
{
    public interface ICommon : IProvider
    {
        //
        // PROPERTIES
        //

        IScope Scope { get; set; }
    }
}
