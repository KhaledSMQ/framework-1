// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model
{
    public class Entity :
        IID<int>,
        IName<string>,
        IDescription<string>,
        ITypeName<string>,
        IConfigList<Setting>,
        IAuditable<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // AUDITS
        //

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Entity()
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            TypeName = string.Empty;
            Settings = null;

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
