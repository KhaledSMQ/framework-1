// ============================================================================
// Project: Framework
// Name/Class: CollectionExtensions
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Collection extensions methods.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Helpers
{
    public static class CollectionExtensions
    {
        //
        // Determines whether the collection is not null and not empty.
        //

        public static bool NotEmpty<T>(ICollection<T> coll)
        {
            return ((null != coll) && (coll.Count() > 0));
        }      
    }
}