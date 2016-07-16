// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Data.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FW_DataQuery : ABaseClassWithID<int, string>
    {
        //
        // PROPERTIES
        //
   
        public TypeOfDataQuery Kind { get; set; }

        public string Name { get; set; }

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
        // CONSTRUCTORS
        // 

        public FW_DataQuery()
        {
            Kind = TypeOfDataQuery.UNKNOWN;
            Name = string.Empty;
            Expression = string.Empty;
            Params = null;
            Callback = string.Empty;
        }
    }
}
