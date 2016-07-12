// ============================================================================
// Project: Framework
// Name/Class: Meta
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Application meta information.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Cloud.Model.Objects
{
    public class Meta :
        IName<string>,
        IDescription<string>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public string Build { get; set; }

        public ICollection<string> Authors { get; set; }

        public string Icon { get; set; }

        //
        // CONSTRUCTOR
        // 

        public Meta()
        {
            Name = default(string);
            Description = default(string);
            Version = default(string);
            Build = default(string);
            Authors = default(ICollection<string>);
            Icon = default(string);
        }
    }
}
