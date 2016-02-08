﻿// ============================================================================
// Project: Framework
// Name/Class: IHub
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Service hub interface.
// ============================================================================

using Framework.Factory.Model;
using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface
{
    public interface IHub : ICommon
    {
        T Get<T>() where T : ICommon;

        T Get<T>(ServiceEntry cfg) where T : ICommon;
    }
}
