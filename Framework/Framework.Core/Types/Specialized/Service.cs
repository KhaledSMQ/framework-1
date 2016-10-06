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

namespace Framework.Core.Types.Specialized
{
    public class Service : 
        IID<int>, 
        IName<string>,
        IDescription<string>,
        ITypeName<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string Module { get; set; }

        public bool Unique { get; set; }

        public bool Default { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contract { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
       
        //
        // CONSTRUCTORS
        // 

        public Service()
        {   
            ID = -1;
            Module = default(string);
            Unique = default(bool);
            Default = default(bool);
            Name = default(string);
            Description = default(string);
            Contract = default(string);
            TypeName = default(string);
            Settings = default(ICollection<Setting>);
        }
    }
}
