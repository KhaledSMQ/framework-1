// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;

namespace Framework.Factory.Model.Relational
{
    public class FW_FactoryServiceEntry : 
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

        public bool Default { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contract { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<FW_FactorySetting> Settings { get; set; }

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

        public FW_FactoryServiceEntry()
        {
            //
            // Basic info.
            //

            ID = -1;
            Unique = false;
            Default = false;
            Name = string.Empty;
            Description = string.Empty;
            Contract = string.Empty;
            TypeName = string.Empty;
            Settings = null;

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
