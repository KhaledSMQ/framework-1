// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Relational
{
    public class FW_ContentDataEntity :
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
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public FW_ContentDataEntityDefinition Definition { get; set; }
        public FW_ContentDataWebApi Api { get; set; }
        public virtual ICollection<FW_ContentDataView> Views { get; set; }
        public virtual ICollection<FW_ContentDataSchema> Schemas { get; set; }
        public virtual ICollection<FW_ContentDataForm> Forms { get; set; }

        [JsonIgnore]
        public virtual FW_ContentDataCluster Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_ContentDataEntity()
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
            Name = string.Empty;
            Icon = string.Empty;
            Description = string.Empty;
            Definition = null;
            Api = null;
            Views = null;
            Schemas = null;
            Forms = null;
            Owner = null;
        }
    }
}
