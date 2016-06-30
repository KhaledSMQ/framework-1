// ============================================================================
// Project: Framework
// Name/Class: Folder
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Data folder modelling class.
// ============================================================================

using Framework.Storage.Patterns;

namespace Framework.Storage.Model
{
    public class Folder : File, IFolder
    {
        //
        // PROPERTIES
        //

        public IFileSet Files { get; set; }

        //
        // CONSTRUCTORS
        //

        public Folder()
            : base(FileType.FOLDER)
        {
            Files = null;
        }
    }
}
