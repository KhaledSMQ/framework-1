// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;

namespace Framework.Client.Model.Objects
{
    public class Client : ABaseClassWithID<string, int>, IOwner<string>
    {
        //
        // PROPERTIES
        //

        public string Owner { get; set; }

        public string Description { get; set; }

        //
        // CONSTRUCTORS
        //

        public Client()
        {
            Owner = default(string);
            Description = default(string);
        }
    }
}
