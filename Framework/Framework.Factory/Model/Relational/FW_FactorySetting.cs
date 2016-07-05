// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;

namespace Framework.Factory.Model.Relational
{
    public class FW_FactorySetting : 
        IConfigSetting<int, string, string, string>, 
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

        public FW_FactorySetting()
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
