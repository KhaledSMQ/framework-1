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

namespace Framework.Cloud.Model.Relational
{
    public class Platform : ABaseClassWithID<string, string>
    {
        //
        // PROPERTIES
        //

        public Settings Settings { get; set; }

        public ICollection<Domain> Domains { get; set; }

        //
        // CONSTRUCTORS
        //

        public Platform()
        {
            Settings = default(Settings);
            Domains = default(ICollection<Domain>);
        }
    }
}
