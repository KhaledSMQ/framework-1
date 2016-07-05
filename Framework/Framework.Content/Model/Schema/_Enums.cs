// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Content.Model.Schema
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
