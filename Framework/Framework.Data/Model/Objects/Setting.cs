// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
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
