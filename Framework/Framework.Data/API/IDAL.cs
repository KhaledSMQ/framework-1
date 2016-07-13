// ============================================================================
// Project: Framework
// Name/Class: Data Access Layer
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 31/May/2016
// Company: Coop4Creativity
// Description: Data Access Layer service contract.
// ============================================================================

using Framework.Data.Model.Mem;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface IDAL : ICommon
    {
        object Create(IDataContext provider, MemEntity entity, object value);

        object Delete(IDataContext provider, MemEntity entity, object value);

        object Query(IDataContext provider, MemQuery query, MemEntity entity, object args);

        object Update(IDataContext provider, MemEntity entity, object value);
    }
}