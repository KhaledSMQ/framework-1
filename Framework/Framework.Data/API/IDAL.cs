// ============================================================================
// Project: Framework
// Name/Class: Data Access Layer
// Author: João Carreiro (joao.carreiro@cybermap.pt)
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
        object Create(IProviderDataContext provider, MemEntity entity, object value);

        object Delete(IProviderDataContext provider, MemEntity entity, object value);

        object Query(IProviderDataContext provider, MemQuery query, MemEntity entity, object args);

        object Update(IProviderDataContext provider, MemEntity entity, object value);
    }
}