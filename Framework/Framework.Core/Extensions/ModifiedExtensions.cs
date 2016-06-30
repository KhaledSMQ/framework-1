// ============================================================================
// Project: Frameowrk
// Name/Class: ModifiedExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 29/Oct/2015
// Company: Coop4Creativity
// Description: Extension methods for modified datatype.
// ============================================================================                    

using System;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public static class ModifiedExtensions
    {
        //
        // Initialize a modified object type.
        //

        public static void Init<T>(this IModified<T> item, T owner)
        {
            item.Init(DateTime.UtcNow, owner);
        }

        public static void Init<T>(this IModified<T> item, DateTime date, T owner)
        {
            if (null != item)
            {
                //
                // Owner bit.
                //

                item.ModifiedBy = owner;

                //
                // Date related bit.
                //

                item.ModifiedDate = date;
            }
        }

        //
        // Modify a modified object.
        //

        public static void Modify<T>(this IModified<T> item, T owner)
        {
            item.Modify(DateTime.UtcNow, owner);
        }

        public static void Modify<T>(this IModified<T> item, DateTime date, T owner)
        {
            if (null != item)
            {
                //
                // Owner bit.
                //

                item.ModifiedBy = owner;

                //
                // Date related bit.
                //

                item.ModifiedDate = date;
            }
        }
    }
}
