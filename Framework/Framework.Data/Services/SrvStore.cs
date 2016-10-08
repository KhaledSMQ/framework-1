// ============================================================================
// Project: Framework
// Name/Class: SrvStore
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Data store service implementation.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Api;

namespace Framework.Data.Services
{
    public class SrvStore<TUser> : ACommon, IStore<TUser>
    {
        //
        // Service dependencies.
        //

        public ISchema<TUser> Schema { get { return SrvSchema; } }

        public IDal<TUser> Dal { get { return SrvDal; } }

        public IRuntime<TUser> Runtime { get { return SrvRuntime; } }

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

            SrvSchema = Scope.Hub.Get<ISchema<TUser>>();
            SrvDal = Scope.Hub.Get<IDal<TUser>>();
            SrvRuntime = Scope.Hub.Get<IRuntime<TUser>>();

            //
            // Setup dependent services.
            //

            SrvDal.Schema = SrvSchema;
            SrvDal.Runtime = SrvRuntime;

            SrvRuntime.Schema = SrvSchema;

            SrvSchema.Dal = SrvDal;
        }

        //
        // Internal storage.
        //

        protected ISchema<TUser> SrvSchema;
        protected IDal<TUser> SrvDal;
        protected IRuntime<TUser> SrvRuntime;
    }
}
