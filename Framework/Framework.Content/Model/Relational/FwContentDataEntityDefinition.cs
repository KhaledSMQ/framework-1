// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Content.Model.Relational
{
    public class FwContentDataEntityDefinition : IID<int>, IAuditable<string>
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

        public FwContentDataEntityDefinition()
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
