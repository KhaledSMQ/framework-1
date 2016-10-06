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
    public class FW_DataContext : ABaseClassWithID<int, string>
    {
        //
        // INFO
        //

        public string Name { get; set; }  

        public FW_DataProvider Provider { get; set; }

        public ICollection<FW_DataEntity> Entities { get; set; }

        public ICollection<FW_DataPartialModel> Models { get; set; }

        public ICollection<FW_DataSetting> Settings { get; set; }  

        //
        // CONSTRUCTORS
        // 

        public FW_DataContext()
        {
            Name = default(string);
            Provider = null;
            Entities = null;
            Models = null;
            Settings = null;
        }
    }
}
