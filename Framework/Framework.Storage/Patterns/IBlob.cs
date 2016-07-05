// ============================================================================
// Project: Framework
// Name/Class: IBlob
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Data blob modelling behaviour.
// ============================================================================

namespace Framework.Storage.Patterns
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
