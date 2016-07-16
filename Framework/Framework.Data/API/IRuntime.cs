// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 16/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface IRuntime<TUser> : ICommon
    {
        //
        // Schema Access Data Layer Service.
        //

        ISchema<TUser> Schema { get; set; }

        //
        // Runtime Access Layer API
        //

        IDataContext<TUser> GetDataContext(string id);

        IDataContext<TUser> GetDataContext(Id id);
    }
}