// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 16/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Core.Api;

namespace Framework.Data.Api
{
    public interface IRuntime<TUser> : ICommon
    {
        //
        // Data Schema Access Layer Service.
        //

        ISchema<TUser> Schema { get; set; }

        //
        // Runtime Access Layer API
        //

        IDataContext<TUser> GetDataContext(string id);

        IDataContext<TUser> GetDataContext(Id id);
    }
}