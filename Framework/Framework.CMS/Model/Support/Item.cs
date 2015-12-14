// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.CMS.Model.Support
{
    public class Item :
        IID<int>,
        ICreated<string>,
        IModified<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        //
        // CONSTRUCTORS
        //

        public Item()
        {
            ID = -1;

            CreatedBy = string.Empty;
            CreatedDate = DateTime.Now;
            ModifiedBy = string.Empty;
            ModifiedDate = DateTime.Now;
        }
    }
}
