// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
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
