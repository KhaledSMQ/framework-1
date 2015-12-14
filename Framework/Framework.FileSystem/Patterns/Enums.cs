// ============================================================================
// Project: Framework
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/July/2013
// Company: Cybermap Lta.
// Description: Enumerations for this namespace.
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.FileSystem.Patterns
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
