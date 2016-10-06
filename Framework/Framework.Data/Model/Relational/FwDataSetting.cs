// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Model.Relational
{
    public class FwDataSetting : ABaseClassWithID<int, string>
    {
        //
        // INFO
        //

        public string Name { get; set; }

        public string Value { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FwDataSetting()
        {
            Name = default(string);
            Value = default(string);
        }
    }
}
