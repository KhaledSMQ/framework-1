// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model
{
    public class DataStore : IDataStore<DataCluster, DataContext, DataModel, DataEntity, Setting>
    {
        //
        // Info
        //

        public ICollection<Setting> Settings { get; set; }

        public ICollection<DataCluster> Clusters { get; set; }

        //
        // CONSTRUCTORS
        // 

        public DataStore()
        {
            Settings = null;
            Clusters = null;
        }
    }
}
