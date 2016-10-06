// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Data.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FwDataContext : ABaseClassWithID<int, string>
    {
        //
        // INFO
        //

        public string Name { get; set; }  

        public FwDataProvider Provider { get; set; }

        public ICollection<FwDataEntity> Entities { get; set; }

        public ICollection<FwDataPartialModel> Models { get; set; }

        public ICollection<FwDataSetting> Settings { get; set; }  

        //
        // CONSTRUCTORS
        // 

        public FwDataContext()
        {
            Name = default(string);
            Provider = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
