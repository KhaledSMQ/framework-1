// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
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
    public class FwDataPartialModel : ABaseClassWithID<int, string>
    {
        //
        // PROPERTIES
        //

        public string TypeName { get; set; }

        public ICollection<FwDataSetting> Settings { get; set; }    

        //
        // CONSTRUCTORS
        // 

        public FwDataPartialModel()
        {
            TypeName = default(string);
            Settings = null;
        }
    }
}
