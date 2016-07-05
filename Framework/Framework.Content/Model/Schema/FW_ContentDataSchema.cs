// ============================================================================
// Project: Framework
// Name/Class: Schema
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Schema
{
    public class FW_ContentDataSchema :
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

        public TypeOfEntitySchema Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FW_ContentDataProperty> Properties { get; set; }

        [JsonIgnore]
        public virtual FW_ContentDataEntity Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_ContentDataSchema()
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

            Type = TypeOfEntitySchema.UNKNOWN;
            Name = string.Empty;
            Description = string.Empty;
            Properties = null;
            Owner = null;
        }
    }
}
