// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Schema;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Import
{
    public class ImportEntity :
        IID<int>,
        IName<string>,
        IDescription<string>,
        ITypeName<string>,
        IConfigList<Setting>,
        IAuditable<string>
    {
        //
        // INFO
        //

        public int ID { get; set; }

        public TypeOfDataEntity Kind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public ICollection<ImportQuery> Queries { get; set; }

        public ICollection<Setting> Settings { get; set; }

        //
        // AUDITS
        //

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportEntity()
        {
            //
            // INFO
            //

            ID = -1;
            Kind = TypeOfDataEntity.DATA_SET;
            Name = string.Empty;
            Description = string.Empty;
            TypeName = string.Empty;
            Queries = null;
            Settings = null;

            //
            // AUDITS
            //

            AuditableExtensions.Init(this, string.Empty);
        }
    }
}
