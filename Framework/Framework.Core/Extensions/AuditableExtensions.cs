// ============================================================================
// Project: Toolkit
// Name/Class: AuditableExtensions
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 14/Abr/2014
// Company: Cybermap Lta.
// Description: Extension methods for list datatype.
// ============================================================================                    

using System;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public static class AuditableExtensions
    {
        //
        // Initialize an auditable object type.
        //

        public static void Init<T>(this IAuditable<T> item, T owner)
        {
            if (null != item)
            {
                //
                // Date related bit.
                //

                DateTime now = DateTime.UtcNow;
                DateTime createdDate = new DateTime(now.Ticks).ToUniversalTime();
                DateTime modifiedDate = new DateTime(now.Ticks).ToUniversalTime();

                CreatedExtensions.Init<T>(item, createdDate, owner);
                ModifiedExtensions.Init<T>(item, modifiedDate, owner);
            }
        }

        //
        // Modify an autidable object.
        //

        public static void Modify<T>(this IAuditable<T> item, T owner)
        {
            ModifiedExtensions.Init<T>(item, DateTime.UtcNow, owner);
        }
    }
}
