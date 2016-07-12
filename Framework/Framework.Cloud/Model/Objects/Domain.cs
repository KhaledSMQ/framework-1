// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;
using Framework.Core.Extensions;
using Framework.Server.Model.Objects;
using Framework.Client.Model.Objects;
using System.Collections.Generic;

namespace Framework.Cloud.Model.Objects
{
    public class Domain :
        IOwner<int>,
        IID<int>,
        IVisible,
        IAuditable<string>,
        IRef<string>
    {
        //
        // PROPERTIES
        //

        public int Owner { get; set; }

        public int ID { get; set; }

        public TypeOfVisibility Visibility { get; set; }

        //
        // AUDITABLE
        //

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        //
        // REF/NAME/DESCRIPTION
        //

        public string Ref { get; set; }

        public Meta Meta { get; set; }

        //
        // CONSTRUCTORS
        //

        public Domain()
        {
            //
            // Base
            //

            Owner = default(int);
            ID = default(int);
            Visibility = TypeOfVisibility.ACTIVE;

            //
            // Auditable
            //

            AuditableExtensions.Init(this, null);

            //
            // Ref/Name/Description
            //

            Ref = default(string);
            Meta = default(Meta);
        }
    }
}
