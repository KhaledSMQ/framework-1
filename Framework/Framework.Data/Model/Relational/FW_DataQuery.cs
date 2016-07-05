// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FW_DataQuery :
        IID<int>,
        IName<string>,
        IDescription<string>,
        IAuditable<string>
    {
        //
        // INFO
        //

        public int ID { get; set; }

        public TypeOfDataQuery Kind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //
        // Definition for query parameters.
        // If empty then the query takes no
        // parameters.
        //

        public ICollection<FW_DataQueryParam> Params { get; set; }

        //
        // In case the query is an expression,
        // the following property contains the 
        // expression.
        //

        public string Expression { get; set; }

        //
        // In case the query is a callback
        // The following property contains
        // The full name description, e.g.
        // class and method of the static
        // method to use. These methods
        // have all the same signature.
        //

        public string Callback { get; set; }

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

        public FW_DataQuery()
        {
            //
            // INFO
            //

            ID = -1;
            Kind = TypeOfDataQuery.UNKNOWN;
            Name = string.Empty;
            Description = string.Empty;
            Expression = string.Empty;
            Params = null;
            Callback = string.Empty;

            //
            // AUDITS
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
