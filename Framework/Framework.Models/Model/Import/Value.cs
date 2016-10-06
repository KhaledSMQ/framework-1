// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Models.Model.Import
{
    public class Value<T> 
    {
        //
        // PROPERTIES
        //

        public IDictionary<string, T> Variations { get; set; }

        //
        // CONSTRUCTORS
        // 

        public Value()
        {
            Variations = null;
        }
    }
}
