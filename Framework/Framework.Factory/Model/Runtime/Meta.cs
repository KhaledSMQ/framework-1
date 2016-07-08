﻿// ============================================================================
// Project: Framework
// Name/Class: Meta
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Application meta information.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Factory.Model.Runtime
{
    public class Meta
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public string Build { get; set; }

        public IList<string> Authors { get; set; }

        public string Icon { get; set; }

        //
        // CONSTRUCTOR
        // 

        public Meta()
        {
            Name = string.Empty;
            Description = string.Empty;
            Version = string.Empty;
            Build = string.Empty;
            Authors = new List<string>();
            Icon = string.Empty;
        }
    }
}
