﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Content.Data.Model.Schema
{
    public class FW_ContentDataEntityDefinition : IID<int>, IAuditable<string>
    {
        //
        // Base
        //

        public int ID { get; set; }

        //
        // Audit
        //

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        //
        // Info.
        //


        //
        // CONSTRUCTORS
        //

        public FW_ContentDataEntityDefinition()
        {
            //
            // Base
            //

            ID = -1;

            DateTime dateNow = DateTime.Now;
            CreatedDate = new DateTime(dateNow.Ticks);
            ModifiedDate = new DateTime(dateNow.Ticks);
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;

            //
            // Info.
            //
        }
    }
}
