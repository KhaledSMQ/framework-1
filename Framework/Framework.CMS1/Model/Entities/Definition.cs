// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using Toolkit.Core.Patterns;

namespace Framework.CMS1.Model.Entities
{
    public class Definition : IID<int>, ICreated<string>, IModified<string>
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

        public Definition()
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
