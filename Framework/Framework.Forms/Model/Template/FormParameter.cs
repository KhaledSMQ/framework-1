// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Forms.Model.Template
{
    public class FormParameter
    { 
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FormParameter()
        {
            Name = string.Empty;
            Description = string.Empty;
            Value = string.Empty;
            Required = false;
        }
    }
}
