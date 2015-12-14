// ============================================================================
// Project: Framework
// Name/Class: IFile
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: File modelling behaviour.
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.FileSystem.Patterns
{
    public interface IFile : IID<int>
    {
        //
        // PROPERTIES
        //

        FileType Type { get; set; }
        string Filename { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        string Path { get; set; }
    }
}
