// ============================================================================
// Project: Framework
// Name/Class: IDrive
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: A drive is a set of files.
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Storage.Patterns
{
    public interface IDrive : IID<int>
    {
        //
        // PROPERTIES
        //

        string Name { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        IFileSet Files { get; set; }
    }
}
