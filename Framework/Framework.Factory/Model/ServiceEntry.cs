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

namespace Framework.Factory.Model
{
    public class ServiceEntry : 
        IID<int>, 
        IName<string>, 
        ITypeName<string>, 
        IAuditable<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public bool Unique { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contract { get; set; }

        public string Service { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }

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

        public ServiceEntry()
        {
            //
            // Basic info.
            //

            ID = -1;
            Unique = false;
            Name = string.Empty;
            Description = string.Empty;
            Contract = string.Empty;
            Service = string.Empty;
            Settings = null;

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
