// ============================================================================
// Project: Framework
// Name/Class: IDataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data store specification contract.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Patterns
{
    public interface IDataStore<TCluster, TContext, TModel, TEntity, TSetting> : 
        IConfigList<TSetting>
        where TContext : IDataContext<TSetting>
        where TModel : IDataModel<TSetting>
        where TEntity : IDataEntity<TSetting>
        where TSetting : IConfigSetting<int, string, string, string>
        where TCluster : IDataCluster<TContext, TModel, TEntity, TSetting>
    {
        //
        // PROPERTIES
        //

        ICollection<TCluster> Clusters { get; set; }
    }
}
