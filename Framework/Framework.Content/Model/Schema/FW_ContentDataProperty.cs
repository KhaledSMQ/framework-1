// ============================================================================
// Project: Framework
// Name/Class: Property
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using System;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Schema
{
    public class FW_ContentDataProperty :
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

        public bool IsKey { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public bool Editable { get; set; }

        [JsonIgnore]
        public virtual FW_ContentDataSchema Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_ContentDataProperty()
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

            IsKey = false;
            Name = string.Empty;
            DisplayName = string.Empty;
            Description = string.Empty;
            Type = string.Empty;
            Required = false;
            Editable = true;
            Owner = null;
        }
    }
}
