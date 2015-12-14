// ============================================================================
// Project: Framework
// Name/Class: Drive
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: A drive is a set of files/folders.
// ============================================================================

using Framework.FileSystem.Patterns;
using System;

namespace Framework.FileSystem.Model
{
    public class Drive : IDrive
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public IFileSet Files { get; set; }

        //
        // CONSTRUCTORS
        //

        public Drive(FileType type)
        {
            ID = -1;
            Name = string.Empty;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;
            Files = null;
        }
    }
}
