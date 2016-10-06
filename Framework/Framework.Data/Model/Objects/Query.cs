// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Relational;
using System.Collections.Generic;

namespace Framework.Data.Model.Objects
{
    public class Query<TUser> : ASchemaObject<TUser>
    {
        //
        // PROPERTIES
        //

        public TypeOfDataQuery Kind { get; set; }

        //
        // Definition for query parameters.
        // If empty then the query takes no
        // parameters.
        //

        public ICollection<QueryParam<TUser>> Params { get; set; }

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

        public Query()
        {
            Kind = TypeOfDataQuery.UNKNOWN;
            Expression = default(string);
            Params = null;
            Callback = default(string);
        }
    }
}
