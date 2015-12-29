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
    public class Store 
    {
        //
        // PROPERTIES
        //

        public ICollection<Cluster> Clusters { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Store()
        {
            Clusters = null;
            Settings = null;
        }
    }
}
