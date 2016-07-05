// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Relational
{
    public class FW_ContentDataWebApi : IID<int>, ICreated<string>, IModified<string>
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

        public string Create { get; set; }
        public string Detail { get; set; }
        public string List { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_ContentDataWebApi()
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

            Create = string.Empty;
            Detail = string.Empty;
            List = string.Empty;
            Update = string.Empty;
            Delete = string.Empty;
        }
    }
}
