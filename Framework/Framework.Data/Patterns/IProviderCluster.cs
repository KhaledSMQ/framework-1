// ============================================================================
// Project: Framework
// Name/Class: IProviderDataCluster
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data cluster behaviour.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Patterns
{
    public interface IProviderCluster : IProvider
    {
        //
        // Data context related methods.
        //

        void SetDataContext(IProviderContext context);

        IProviderContext GetDataContext();

        //
        // Entity storage factory methods.
        //

        IDataSet<T> GetDataSet<T>();

        IDataSet<T> GetDataSet<T>(IConfigMap cfg);

        IDataObject<T> GetDataObject<T>();

        IDataObject<T> GetDataObject<T>(IConfigMap cfg);
    }
}
