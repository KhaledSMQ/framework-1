﻿// ============================================================================
// Project: Framework
// Name/Class: ACommon
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service implementation.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Factory.Patterns
{
    public abstract class ACommon : ICommon
    {
        //
        // PROPERTIES
        // 

        public IConfigMap Cfg { get; set; }

        public IScope Ctx { get; set; }

        //
        // INITIALIZATION
        //

        public virtual void Init(IConfigMap config)
        {
            Cfg = config;
        }

        //
        // SHUTDOWN
        //

        public virtual void Shutdown() { }
    }
}
