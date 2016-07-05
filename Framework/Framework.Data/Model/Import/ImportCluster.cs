// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 27/May/2015
// Company: Coop4Creativity
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

        public int Owner { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ImportContext> Contexts { get; set; }

        public ICollection<ImportEntity> Entities { get; set; }

        public ICollection<ImportPartialModel> Models { get; set; }

        public ICollection<ImportSetting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportCluster()
        {
            Owner = default(int);
            Name = default(string);
            Description = default(string);
            Contexts = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
