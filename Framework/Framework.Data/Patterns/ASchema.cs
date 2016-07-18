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
using Framework.Core.Patterns;

namespace Framework.Data.API
{
    public abstract class ASchema<TUser> : ACommon
    {
        //
        // Data Access Layer Service.
        //

        public IDal<TUser> Dal { get; set; }

        //
        // Data Schema Access Service API.
        //

        public abstract void Create<T>(T item) where T : ASchemaObject<TUser>;

        public virtual T Get<T>(T item) where T : ASchemaObject<TUser>
        {
            return Get<T>(item.ID);
        }

        public virtual T Get<T>(string id) where T : ASchemaObject<TUser>
        {
            return Get<T>(Id.FromString(id));
        }

        public abstract T Get<T>(Id id) where T : ASchemaObject<TUser>;

        public abstract void Update<T>(T item) where T : ASchemaObject<TUser>;

        public virtual void Delete<T>(T item) where T : ASchemaObject<TUser>
        {
            Delete<T>(item.ID);
        }

        public virtual void Delete<T>(string id) where T : ASchemaObject<TUser>
        {
            Delete<T>(Id.FromString(id));
        }

        public abstract void Delete<T>(Id id) where T : ASchemaObject<TUser>;
    }
}