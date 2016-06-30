// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportContext
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public ImportProvider Provider { get; set; }

        public ICollection<ImportEntityRef> Entities { get; set; }

        public ICollection<ImportPartialModelRef> Models { get; set; }

        public ICollection<ImportSetting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportContext()
        {
            Name = string.Empty;
            Description = string.Empty;
            Provider = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
