// ============================================================================
// Project: Framework
// Name/Class: Blob
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Data blob modelling class.
// ============================================================================

using Framework.FileSystem.Patterns;

namespace Framework.FileSystem.Model
{
    public class Blob : File, IBlob
    {
        //
        // PROPERTIES
        //

        public string MimeType { get; set; }
        public byte[] Content { get; set; }

        //
        // CONSTRUCTORS
        //

        public Blob()
            : base(FileType.BLOB)
        {
            MimeType = string.Empty;
            Content = null;
        }
    }
}
