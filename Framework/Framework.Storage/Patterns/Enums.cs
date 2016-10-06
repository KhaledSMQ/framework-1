// ============================================================================
// Project: Framework
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 17/July/2013
// Company: Coop4Creativity
// Description: Enumerations for this namespace.
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Storage.Patterns
{
    //
    // Enumeration for file types.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        UNKNOWN,
        FOLDER,
        BLOB
    };
}
