// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Blocks.Api;
using Framework.Blocks.Model.Objects;
using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Blocks.Services
{
    public class SrvEval : ACommon, IEval
    {
        //
        // Service dependencies.
        //

        protected IStore Store { get; set; }

        //
        // Service initialization. 
        // Boot the dependant services.
        //

        public override void Init()
        {
            //
            // Initialize base service infrastructure.
            //

            base.Init();
        }
    }
}
