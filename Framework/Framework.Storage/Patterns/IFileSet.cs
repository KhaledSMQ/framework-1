// ============================================================================
// Project: Framework
// Name/Class: IFile
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: File modelling behaviour.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Storage.Patterns
{
    public interface IFileSet : ICollection<IFile>, IList<IFile> { }
}
