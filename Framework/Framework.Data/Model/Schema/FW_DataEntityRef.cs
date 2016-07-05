﻿// ============================================================================
// Project: Framework
// Name/Class: 
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

namespace Framework.Data.Model.Schema
{
    public class FW_DataEntityRef :
        IID<int>,
        IName<string>,     
        IAuditable<string>
    {
        //
        // INFO
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<FW_DataSetting> Settings { get; set; }

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

        public FW_DataEntityRef()
        {
            //
            // INFO
            //

            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Settings = null;

            //
            // AUDITS
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
