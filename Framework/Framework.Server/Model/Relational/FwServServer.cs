// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Server.Model.Relational
{
    public class FwServServer : ABaseClassWithID<string, string>, IOwner<string>
    {
        //
        // PROPERTIES
        //

        public string Owner { get; set; }

        public string Description { get; set; }

        public ICollection<FwServModule> Modules { get; set; }

        //
        // CONSTRUCTORS
        //

        public FwServServer()
        {
            Owner = default(string);
            Description = default(string);
            Modules = default(ICollection<FwServModule>);
        }
    }
}
