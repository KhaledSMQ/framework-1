// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Server.Model.Relational
{
    public class FwServService : 
        IID<int>, 
        IName<string>, 
        ITypeName<string>, 
        IAuditable<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Module { get; set; }

        public bool Unique { get; set; }

        public bool Default { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contract { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<FwServSetting> Settings { get; set; }

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

        public FwServService()
        {
            //
            // Basic info.
            //

            ID = default(int);
            Module = default(string);
            Unique = default(bool);
            Default = default(bool);
            Name = default(string);
            Description = default(string);
            Contract = default(string);
            TypeName = default(string);
            Settings = default(ICollection<FwServSetting>);

            //
            // Audits
            //

            AuditableExtensions.Init(this, default(string));
        }
    }
}
