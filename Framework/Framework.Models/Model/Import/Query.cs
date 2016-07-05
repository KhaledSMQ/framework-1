// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Models.Model.Import
{
    public class Query :
        IName<string>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public Value<string> Description { get; set; }

        public string Expression { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Query()
        {
            Name = default(string);
            Description = default(Value<string>);
            Expression = null;
        }
    }
}
