// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using System.Collections.Generic;
using Framework.CMS1.Model.Entities;
using Framework.CMS1.Model.Types;
using Toolkit.Core.Patterns;

namespace Framework.CMS1.Model
{
    public class Cluster :
        IID<int>,
        IVisible,
        ICreated<string>,
        IModified<string>,
        IRef<string>,
        IName<string>,
        IDescription<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }
        public TypeOfVisibility Visibility { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string Ref { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Entity> Entities { get; set; }

        public virtual ICollection<ContentType> ContentTypes { get; set; }

        //
        // CONSTRUCTORS
        //

        public Cluster()
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
            Description = string.Empty;
            Entities = null;
            ContentTypes = null;
        }
    }
}
