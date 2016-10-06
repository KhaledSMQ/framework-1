// ============================================================================
// Project: Framework
// Name/Class: Blob
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Data blob modelling class.
// ============================================================================

using Framework.Storage.Patterns;

namespace Framework.Storage.Model.Objects
{
    public class Blob : File, IBlob
    {
        //
        // PROPERTIES
        //

        public string MimeType { get; set; }

        public string Encoding { get; set; }

        public byte[] Content { get; set; }

        //
        // CONSTRUCTORS
        //

        public Blob()
            : base(FileType.BLOB)
        {
            MimeType = default(string);
            Encoding = default(string);
            Content = null;
        }
    }
}
