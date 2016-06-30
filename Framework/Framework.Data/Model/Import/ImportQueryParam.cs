// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

namespace Framework.Data.Model.Import
{
    public class ImportQueryParam 
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }

        public string Description { get; set; }

        public string TypeName { get; set; }

        public bool Required { get; set; }

        public string Default { get; set; }

        //
        // CONSTRUCTORS
        // 

        public ImportQueryParam()
        {
            Name = default(string);
            Description = default(string);
            TypeName = default(string);
            Required = false;
            Default = default(string);        
        }
    }
}
