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
using System.Collections.Generic;

namespace Framework.Types.Model.Schema
{
    public class FwTypCluster :
        IOwner<int>,
        IID<int>,
        IName<string>,
        IDescription<string>,
        IAuditable<string>
    {
        //
        // Info
        //

        public int Owner { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<FwTypTypeDef> TypeDefs { get; set; }
      
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

        public FwTypCluster()
        {
            //
            // Info
            //

            Owner = -1;
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            TypeDefs = null;
          

            //
            // Audits
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
