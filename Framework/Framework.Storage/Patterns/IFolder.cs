// ============================================================================
// Project: Framework
// Name/Class: IFolder
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: File modelling behaviour.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Storage.Patterns
{
    public interface IFolder : IFile
    {
        //
        // PROPERTIES
        //

        IFileSet Files { get; set; }
    }
}
