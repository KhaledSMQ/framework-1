// ============================================================================
// Project: Framework
// Name/Class: File
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Data file modelling class.
// ============================================================================

using Framework.Storage.Patterns;
using System;

namespace Framework.Storage.Model
{
    public class File : IFile
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }
        public FileType Type { get; set; }
        public string Filename { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Path { get; set; }

        //
        // CONSTRUCTORS
        //

        public File(FileType type)
        {
            ID = -1;
            Type = type;
            Filename = string.Empty;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;
            Path = string.Empty;
        }

        public File() : this(FileType.UNKNOWN) { }
    }
}
