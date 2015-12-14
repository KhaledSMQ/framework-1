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

namespace Framework.Factory.Model.Config
{
    public class Service : IID<int>, IName<string>, IAuditable<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contract { get; set; }
        public string Type { get; set; }

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

        public Service()
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Contract = string.Empty;
            Type = string.Empty;
            Settings = null;

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
