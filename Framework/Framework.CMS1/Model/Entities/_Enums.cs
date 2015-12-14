// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.CMS1.Model.Entities
{
    //
    // Types of entity schema.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfEntitySchema
    {
        UNKNOWN,
        DEFAULT,
        CREATE,
        VIEW,
        EDIT
    }

    //
    // Types of entity form.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfEntityForm
    {
        UNKNOWN,
        CREATE,
        VIEW,
        EDIT
    }
}
