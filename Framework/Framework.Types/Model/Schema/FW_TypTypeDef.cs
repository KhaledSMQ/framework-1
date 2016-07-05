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

namespace Framework.Types.Model.Schema
{
    public class FW_TypTypeDef :
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

        public string Description { get; set; }

        public bool Abstract { get; set; }

        public bool Primitive { get; set; }

        public bool Internal { get; set; }

        public string BaseType { get; set; }

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

        public FW_TypTypeDef()
        {
            //
            // Info
            //

            ID = -1;
            Name = default(string);
            Description = default(string);
            Abstract = false;
            Primitive = false;
            Internal = false;
            BaseType = default(string);   

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
