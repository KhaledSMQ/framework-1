// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;

namespace Framework.Blocks.API
{
    public class SrvEval : ACommon, IEval
    {
        //
        // Service dependencies.
        //

        protected IStore srvStore { get; set; }

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

            //
            // Initialize dependent services.
            // NOTE: We do this here because all these services
            // do not have dependencies that are circular to this service.
            //

            srvStore = Scope.Hub.GetUnique<IStore>();
        }

        //
        // EVALUATE
        // Evaluate a block based on its unique id.
        //

        public object Eval(string blockID, object args)
        {
            return Eval(new Id(blockID), args);
        }

        public object Eval(Id blockID, object args)
        {
            return null;
        }
    }
}
