// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;

namespace Framework.Data.Model.Objects
{
    public class QueryParam<TUser> : ASchemaObject<TUser>
    {
        //
        // PROPERTIES
        //

        public string TypeName { get; set; }

        public bool Required { get; set; }

        public string Default { get; set; }

        //
        // CONSTRUCTORS
        // 

        public QueryParam()
        {
            TypeName = default(string);
            Required = false;
            Default = default(string);
        }
    }
}
