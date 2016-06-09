﻿// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Web.Server.API
{
    public interface IDummyService : ICommon
    {
        void Run();
    }
}
