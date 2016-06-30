// ============================================================================
// Project: Framework
// Name/Class: FileSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/May/2015
// Company: Coop4Creativity
// Description: Data file set modelling class.
// ============================================================================

using Framework.Storage.Patterns;
using System.Collections.Generic;

namespace Framework.Storage.Model
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
