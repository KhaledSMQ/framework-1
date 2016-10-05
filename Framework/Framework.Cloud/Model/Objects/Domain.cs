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
using System.Collections.Generic;

namespace Framework.Cloud.Model.Objects
{
    public class Domain : ABaseClassWithID<string, string>, IOwner<string>
    {
        //
        // PROPERTIES
        //

        public string Owner { get; set; }

        public Settings Settings { get; set; }

        public ICollection<App.Model.Objects.App> Apps { get; set; }

        //
        // CONSTRUCTORS
        //

        public Domain()
        {
            Settings = default(Settings);
            Apps = default(ICollection<App.Model.Objects.App>);
        }
    }
}
