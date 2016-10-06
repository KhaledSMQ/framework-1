// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 16/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Api;

namespace Framework.Data.Api
{
    public interface IStore<TUser> : ICommon
    {
        //
        // Data Schema Access Layer Service.
        //

        ISchema<TUser> Schema { get; }

        //
        // Data Access Layer Service.
        //

        IDal<TUser> Dal { get; }

        //
        // Runtime Layer Service.
        //

        IRuntime<TUser> Runtime { get; }
    }
}
