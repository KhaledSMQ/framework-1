// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 16/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Model.Objects;
using Framework.Core.Api;

namespace Framework.Data.Api
{
    public interface ISchema<TUser> : ICommon
    {
        //
        // Data Access Layer Service.
        //

        IDal<TUser> Dal { get; set; }

        //
        // Data Schema Access Service API.
        //

        void Create<T>(T item) where T : ASchemaObject<TUser>;

        T Get<T>(T item) where T : ASchemaObject<TUser>;

        T Get<T>(string id) where T : ASchemaObject<TUser>;

        T Get<T>(Id id) where T : ASchemaObject<TUser>;

        void Update<T>(T item) where T : ASchemaObject<TUser>;

        void Delete<T>(T item) where T : ASchemaObject<TUser>;

        void Delete<T>(string id) where T : ASchemaObject<TUser>;

        void Delete<T>(Id id) where T : ASchemaObject<TUser>;
    }
}