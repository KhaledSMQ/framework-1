// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Packages.Model.Objects
{
    public class Document : IID<string>
    {
        //
        // PROPERTIES
        //

        public string ID { get; set; }

        public FileSet Files { get; set; }

        //
        // CONSTRUCTORS
        //

        public Document()
        {
            ID = string.Empty;
            Files = null;
        }
    }
}
