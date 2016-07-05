// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportEntityRef
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ImportSetting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportEntityRef()
        {
            Name = string.Empty;
            Description = string.Empty;
            Settings = null;
        }
    }
}
