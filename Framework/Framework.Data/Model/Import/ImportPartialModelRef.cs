// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportPartialModelRef
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportPartialModelRef()
        {
            Name = string.Empty;
            Description = string.Empty;
            Settings = null;
        }
    }
}
