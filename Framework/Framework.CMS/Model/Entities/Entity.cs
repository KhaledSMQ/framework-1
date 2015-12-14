// ============================================================================
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
using Framework.CMS.Model.Views;
using Framework.Core.Patterns;

namespace Framework.CMS.Model.Entities
{
    public class Entity :
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
        public Definition Definition { get; set; }
        public WebApi Api { get; set; }
        public virtual ICollection<View> Views { get; set; }
        public virtual ICollection<Schema> Schemas { get; set; }
        public virtual ICollection<Form> Forms { get; set; }

        [JsonIgnore]
        public virtual Cluster Owner { get; set; }

        //
        // CONSTRUCTORS
        //

        public Entity()
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
