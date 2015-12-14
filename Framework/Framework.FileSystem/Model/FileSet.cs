// ============================================================================
// Project: Framework
// Name/Class: FileSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/May/2015
// Company: Cybermap Lta.
// Description: Data file set modelling class.
// ============================================================================

using Framework.FileSystem.Patterns;
using System.Collections.Generic;

namespace Framework.FileSystem.Model
{
    public class FileSet : List<IFile>, IFileSet
    {
        //
        // CONSTRUCTORS
        //

        public FileSet() : base() { }

        public FileSet(IEnumerable<IFile> items) : base(items) { }
    }
}
