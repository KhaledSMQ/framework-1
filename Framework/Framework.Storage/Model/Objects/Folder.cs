// ============================================================================
// Project: Framework
// Name/Class: Folder
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Data folder modelling class.
// ============================================================================

using Framework.Storage.Patterns;

namespace Framework.Storage.Model.Objects
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
