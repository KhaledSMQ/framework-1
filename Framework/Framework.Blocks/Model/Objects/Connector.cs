// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;

namespace Framework.Blocks.Model.Objects
{
    public class Connector
    {
        //
        // PROPERTIES
        //

        public Id Name { get; set; }

        //
        // CONSTRUCTORS
        //

        public Connector()
        {
            Name = default(Id);
        }
    }
}
