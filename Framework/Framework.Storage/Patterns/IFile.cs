﻿// ============================================================================
// Project: Framework
// Name/Class: IFile
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: File modelling behaviour.
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Storage.Patterns
{
    public interface IFile : IID<int>
    {
        //
        // PROPERTIES
        //

        FileType Type { get; set; }

        string Name { get; set; }

        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        string ModifiedBy { get; set; }

        DateTime ModifiedDate { get; set; }

        string Path { get; set; }
    }
}
