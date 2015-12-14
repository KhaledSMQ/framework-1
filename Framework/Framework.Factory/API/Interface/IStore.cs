// ============================================================================
// Project: Framework
// Name/Class: IStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data store hub interface.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface
{
    public interface IStore : ICommon
    {
        IProviderDataSet<T> GetDataSet<T>();

        IProviderDataSet<T> GetDataSet<T>(IConfigMap cfg);

        IProviderDataObject<T> GetDataObject<T>();

        IProviderDataObject<T> GetDataObject<T>(IConfigMap cfg);
    }
}
