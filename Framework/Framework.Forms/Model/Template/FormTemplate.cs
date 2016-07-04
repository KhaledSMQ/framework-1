// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 27/May/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Forms.Model.Template
{
    public class FormTemplate : IID<Id>
    {
        //
        // PROPERTIES
        //

        public int Owner { get; set; }

        public Id ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IDictionary<string, FormSetting> Settings { get; set; }

        public IDictionary<string, FormParameter> Params { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FormTemplate()
        {
            Owner = default(int);
            ID = default(Id);
            Name = default(string);
            Description = default(string);
            Settings = null;
            Params = null;
        }
    }
}
