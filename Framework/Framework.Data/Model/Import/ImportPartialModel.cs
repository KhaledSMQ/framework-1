// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportPartialModel 
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportPartialModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            TypeName = string.Empty;
            Settings = null;
        }
    }
}
