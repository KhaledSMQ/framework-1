// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

namespace Framework.Data.Model
{
    //
    // Caracterization of a data entity.
    // Data sets are lists of data records, and
    // data object are single object values.
    //

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

    public enum TypeOfDataQuery
    {
        UNKNOWN,
        EXPRESSION,
        CALLBACK
    }
}
