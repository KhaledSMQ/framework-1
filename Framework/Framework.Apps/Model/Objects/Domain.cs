﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using System.Collections.Generic;
using Framework.Core.Patterns;
using Framework.Core.Extensions;

namespace Framework.Apps.Model.Objects
{
    public class Domain :
        IID<int>,
        IVisible,
        IAuditable<string>,
        IRef<string>,
        IName<string>,
        IDescription<string>
    {
        //
        // PROPERTIES
        //

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

        public string Name { get; set; }

        public string Description { get; set; }
       
        //
        // APPS
        //

        public IDictionary<string, App> Apps { get; set; }

        //
        // CONSTRUCTORS
        //

        public Domain()
        {
            //
            // Base
            //

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
            Name = default(string);
            Description = default(string);

            //
            // Apps
            //

            Apps = default(IDictionary<string, App>);
        }
    }
}