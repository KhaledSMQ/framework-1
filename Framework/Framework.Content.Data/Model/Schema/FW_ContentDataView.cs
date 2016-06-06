﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Content.Data.Model.Schema
{
    public class FW_ContentDataView :
        IID<int>,
        IVisible,
        ICreated<string>,
        IModified<string>,
        IRef<string>,
        IName<string>,
        IDescription<string>
    {
        //
        // Base
        //

        public int ID { get; set; }
        public TypeOfVisibility Visibility { get; set; }

        //
        // Audit
        //

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //
        // Info.
        //

        public string Ref { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FW_ContentDataField> Fields { get; set; }

        [JsonIgnore]
        public virtual FW_ContentDataEntity Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_ContentDataView()
        {
            //
            // Base
            //

            ID = -1;
            Visibility = TypeOfVisibility.ACTIVE;

            DateTime dateNow = DateTime.Now;
            CreatedDate = new DateTime(dateNow.Ticks);
            ModifiedDate = new DateTime(dateNow.Ticks);
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;

            //
            // Info.
            //

            Ref = string.Empty;
            IsDefault = false;
            Name = string.Empty;
            Description = string.Empty;
            Fields = null;
            Owner = null;
        }
    }
}
