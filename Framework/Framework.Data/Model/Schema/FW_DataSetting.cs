// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;

namespace Framework.Data.Model.Schema
{
    public class FW_DataSetting : 
        IAuditable<string>
    {
        //
        // INFO
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

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

        public FW_DataSetting()
        {
            //
            // INFO
            //

            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Value = string.Empty;

            //
            // AUDITS
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
