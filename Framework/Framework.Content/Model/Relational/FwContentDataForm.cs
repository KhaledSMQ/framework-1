﻿// ============================================================================
// Project: Framework
// Name/Class: Schema
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using System;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Relational
{
    public class FwContentDataForm :
        IID<int>,
        IVisible,
        ICreated<string>,
        IModified<string>,
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

        public TypeOfEntityForm Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public virtual FwContentDataEntity Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public FwContentDataForm()
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

            Type = TypeOfEntityForm.UNKNOWN;
            Name = string.Empty;
            Description = string.Empty;
            Url = null;
            Owner = null;
        }
    }
}
