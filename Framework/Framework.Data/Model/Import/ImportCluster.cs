// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 27/May/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportCluster 
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ImportContext> Contexts { get; set; }

        public ICollection<ImportEntity> Entities { get; set; }

        public ICollection<ImportPartialModel> Models { get; set; }

        public ICollection<Setting> Settings { get; set; }  

        //
        // CONSTRUCTORS
        // 

        public ImportCluster()
        {
            Name = string.Empty;
            Description = string.Empty;
            Contexts = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
