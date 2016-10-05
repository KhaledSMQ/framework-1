// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Model.Relational
{
    public class FW_DataSetting : ABaseClassWithID<int, string>
    {
        //
        // INFO
        //

        public string Name { get; set; }

        public string Value { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FW_DataSetting()
        {
            Name = default(string);
            Value = default(string);
        }
    }
}
