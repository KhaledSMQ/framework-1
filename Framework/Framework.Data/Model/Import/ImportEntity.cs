// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Model.Schema;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportEntity 
    {
        //
        // PROPERTIES
        //

        public TypeOfDataEntity Kind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public ICollection<ImportQuery> Queries { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportEntity()
        {
            Kind = TypeOfDataEntity.DATA_SET;
            Name = string.Empty;
            Description = string.Empty;
            TypeName = string.Empty;
            Queries = null;
            Settings = null;
        }
    }
}
