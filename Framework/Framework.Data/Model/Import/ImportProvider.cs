// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportProvider 
    {
        //
        // PROPERTIES
        //

        public bool Unique { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<ImportSetting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportProvider()
        {
            Unique = false;
            Description = string.Empty;
            TypeName = string.Empty;
            Settings = null;
        }
    }
}
