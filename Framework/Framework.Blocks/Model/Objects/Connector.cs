// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;

namespace Framework.Blocks.Model.Objects
{
    public class Connector : IID<Id>
    {
        //
        // PROPERTIES
        //

        public Id ID { get; set; }

        //
        // CONSTRUCTORS
        //

        public Connector()
        {
            ID = default(Id);
        }
    }
}
