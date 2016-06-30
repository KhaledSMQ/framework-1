// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Blocks.Model.Schema
{
    //
    // Caracterization of the connection port.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfPort
    {
        UNKNOWN,
        IN,
        OUT
    }
}
