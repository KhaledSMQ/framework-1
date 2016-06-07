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
    public class FW_DataCluster :
        IOwner<int>,
        IID<int>,
        IName<string>,
        IDescription<string>,
        IAuditable<string>
    {
        //
        // Info
        //

        public int Owner { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<FW_DataContext> Contexts { get; set; }

        public ICollection<FW_DataEntity> Entities { get; set; }

        public ICollection<FW_DataPartialModel> Models { get; set; }

        public ICollection<FW_DataSetting> Settings { get; set; }

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

        public FW_DataCluster()
        {
            //
            // Info
            //

            Owner = -1;
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
