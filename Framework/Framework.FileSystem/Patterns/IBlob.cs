﻿// ============================================================================
// Project: Framework
// Name/Class: IBlob
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Data blob modelling behaviour.
// ============================================================================

namespace Framework.FileSystem.Patterns
{
    public interface IBlob : IFile
    {
        //
        // PROPERTIES
        //

        byte[] Content { get; set; }
        string MimeType { get; set; }
    }
}