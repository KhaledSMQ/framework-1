// ============================================================================
// Project: Framework
// Name/Class: IFolder
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: File modelling behaviour.
// ============================================================================

using System.Collections.Generic;

namespace Framework.FileSystem.Patterns
{
    public interface IFolder : IFile
    {
        //
        // PROPERTIES
        //

        IFileSet Files { get; set; }
    }
}
