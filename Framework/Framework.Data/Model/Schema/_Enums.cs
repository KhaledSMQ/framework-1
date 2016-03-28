﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Data.Model.Schema
{
    //
    // Caracterization of a data entity.
    // Data sets are lists of data records, and
    // data object are single object values.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfDataEntity
    {
        UNKNOWN,
        DATA_SET,
        DATA_OBJECT
    }

    //
    // Caracterization of a data query.
    // Queries can be defined by an expression
    // or by an method. The method follows a 
    // specific signature.
    //

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfDataQuery
    {
        UNKNOWN,
        EXPRESSION,
        CALLBACK
    }
}