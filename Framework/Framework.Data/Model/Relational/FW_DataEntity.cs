// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FW_DataEntity : ABaseClassWithID<int, string>      
    {
        //
        // PROPERTIES
        //

        public TypeOfDataEntity Kind { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public ICollection<FW_DataQuery> Queries { get; set; }

        public ICollection<FW_DataSetting> Settings { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FW_DataEntity()
        {
            Kind = TypeOfDataEntity.DATA_SET;
            Name = default(string);
            TypeName = default(string);
            Queries = null;
            Settings = null;
        }
    }
}
