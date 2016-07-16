// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Data.Model.Objects
{
    public class Setting<TUser> : ASchemaObject<TUser>
    {
        //
        // INFO
        //

        public string Value { get; set; }       

        //
        // CONSTRUCTORS
        // 

        public Setting()
        {
            Value = default(string);  
        }
    }
}
