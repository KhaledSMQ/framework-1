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

namespace Framework.Models.Model.Relational
{
    public class FW_ModProperty :
        IID<int>,
        IName<string>,
        IDescription<string>,
        IAuditable<string>
    {
        //
        // Info
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Localizable { get; set; }

        public bool Nullable { get; set; }

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

        public FW_ModProperty()
        {
            //
            // Info
            //

            ID = -1;
            Name = default(string);
            DisplayName = default(string);
            Description = default(string);
            Localizable = default(bool);
            Nullable = default(bool);

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
