// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

namespace Framework.Data.EntityFramework.Context
{
    //
    // Type of EF model initialization.
    //

    public enum TypeOfDbInitializer
    {
        UNKNOWN,
        CREATE_ALWAYS,
        CREATE_IF_MODEL_CHANGES,
        CREATE_IF_NOT_EXISTS
    }
}
