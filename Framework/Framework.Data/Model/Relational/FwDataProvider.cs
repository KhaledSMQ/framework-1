// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FwDataProvider : ABaseClassWithID<int, string>
    {
        //
        // PROPERTIES
        //

        public string TypeName { get; set; }

        public virtual ICollection<FwDataSetting> Settings { get; set; }      

        //
        // CONSTRUCTORS
        // 

        public FwDataProvider()
        {
            TypeName = default(string);
            Settings = null;
        }
    }
}
