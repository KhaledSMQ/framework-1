// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FW_DataProvider : ABaseClassWithID<int, string>
    {
        //
        // PROPERTIES
        //

        public string TypeName { get; set; }

        public virtual ICollection<FW_DataSetting> Settings { get; set; }      

        //
        // CONSTRUCTORS
        // 

        public FW_DataProvider()
        {
            TypeName = default(string);
            Settings = null;
        }
    }
}
