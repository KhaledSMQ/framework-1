// ============================================================================
// Project: Framework
// Name/Class: ACommon
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base service implementation.
// ============================================================================

using Framework.Core.Api;

namespace Framework.Core.Patterns
{
    public abstract class ACommon : ICommon
    {
        //
        // PROPERTIES
        // 

        public IConfigMap Cfg { get; set; }

        public IScope Scope { get; set; }

        //
        // INITIALIZATION
        //

        public virtual void Init() { }

        //
        // SHUTDOWN
        //

        public virtual void Shutdown() { }
    }
}
