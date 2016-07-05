// ============================================================================
// Project: Framework
// Name/Class: IFile
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: File modelling behaviour.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Storage.Patterns
{
    public interface IFileSet : ICollection<IFile>, IList<IFile> { }
}
