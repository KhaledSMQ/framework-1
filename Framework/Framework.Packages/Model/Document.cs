// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Packages.Model
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
