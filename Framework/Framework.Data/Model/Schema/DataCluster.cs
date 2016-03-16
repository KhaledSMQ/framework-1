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
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Schema
{
    public class DataCluster : 
        IID<int>,
        IName<string>,
        IDescription<string>,
        IAuditable<string>,
        IConfigList<Setting>
    {
        //
        // Info
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<DataContext> Contexts { get; set; }

        public ICollection<DataEntity> Entities { get; set; }

        public ICollection<DataPartialModel> Models { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // Audits
        //

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        //
        // CONSTRUCTORS
        // 

        public DataCluster()
        {
            //
            // Info
            //

            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Contexts = null;
            Entities = null;
            Models = null;
            Settings = null;

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
