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

namespace Framework.Data.API.Interface
{
    public interface IStore : ICommon
    {
        IDataSet<T> GetDataSet<T>();

        IDataSet<T> GetDataSet<T>(IConfigMap cfg);

        IDataObject<T> GetDataObject<T>();

        IDataObject<T> GetDataObject<T>(IConfigMap cfg);
    }
}
