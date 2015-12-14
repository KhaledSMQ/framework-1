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
    public interface IProviderDataCluster : IProvider
    {
        //
        // Data context related methods.
        //

        void SetDataContext(IProviderDataContext context);

        IProviderDataContext GetDataContext();

        //
        // Entity storage factory methods.
        //

        IProviderDataSet<T> GetDataSet<T>();

        IProviderDataSet<T> GetDataSet<T>(IConfigMap cfg);

        IProviderDataObject<T> GetDataObject<T>();

        IProviderDataObject<T> GetDataObject<T>(IConfigMap cfg);
    }
}
