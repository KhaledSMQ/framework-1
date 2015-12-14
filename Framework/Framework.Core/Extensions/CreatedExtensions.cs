// ============================================================================
// Project: Framework
// Name/Class: CreatedExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 14/Abr/2014
// Company: Cybermap Lta.
// Description: Extension methods for created object types.
// ============================================================================                    

using System;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public static class CreatedExtensions
    {
        //
        // Initialize a created object type.
        //

        public static void Init<T>(this ICreated<T> item, T owner)
        {
            item.Init(DateTime.UtcNow, owner);
        }

        public static void Init<T>(this ICreated<T> item, DateTime date, T owner)
        {
            if (null != item)
            {
                //
                // Owner bit.
                //

                item.CreatedBy = owner;

                //
                // Date related bit.
                //

                item.CreatedDate = date;
            }
        }
    }
}
