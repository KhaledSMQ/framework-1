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

namespace Framework.Data.Model.Schema
{
    public class FW_DataProvider : 
        IID<int>, 
        ITypeName<string>, 
        IAuditable<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public bool Unique { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<FW_DataSetting> Settings { get; set; }

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

        public FW_DataProvider()
        {
            //
            // Basic info.
            //

            ID = -1;
            Unique = false;
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
