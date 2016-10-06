// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Content.Model.Relational
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
