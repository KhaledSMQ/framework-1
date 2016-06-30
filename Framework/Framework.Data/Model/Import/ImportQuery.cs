// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Data.Model.Schema;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportQuery
    {
        //
        // PROPERTIES
        //

        public TypeOfDataQuery Kind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //
        // Definition for query parameters.
        // If empty then the query takes no
        // parameters.
        //

        public ICollection<ImportQueryParam> Params { get; set; }

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
        // CONSTRUCTORS
        // 

        public ImportQuery()
        {
            Kind = TypeOfDataQuery.UNKNOWN;
            Name = string.Empty;
            Description = string.Empty;
            Expression = string.Empty;
            Params = null;
            Callback = string.Empty;
        }
    }
}
