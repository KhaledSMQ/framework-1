// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Schema
{
    public class DataPartialModel : 
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

        public DataPartialModel()
        {
            //
            // Info
            //

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
