// ============================================================================
// Project: Framework
// Name/Class: DataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model
{
    public class DataStore : IDataStore<DataCluster, DataContext, DataModel, DataEntity, Setting>
    {
        //
        // PROPERTIES
        //

        public ICollection<DataCluster> Clusters { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public DataStore()
        {
            Clusters = null;
            Settings = null;
        }
    }
}
