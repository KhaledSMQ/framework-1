// ============================================================================
// Project: Framework
// Name/Class: Service
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System;
using System.Collections.Generic;

namespace Framework.Factory.Model.Runtime
{
    public class Module : 
        IName<string>, 
        ITypeName<string>
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }      

        //
        // CONSTRUCTORS
        // 

        public Module()
        {
            //
            // Basic info.
            //

            Name = string.Empty;
            Description = string.Empty;
            TypeName = string.Empty;
            Settings = null;
        }
    }
}
