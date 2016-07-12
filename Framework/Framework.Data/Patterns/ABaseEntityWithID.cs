// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;
using Framework.Core.Extensions;

namespace Framework.Data.Patterns
{
    public class ABaseEntityWithID<TID, TUser> :
        IID<TID>,
        IVisible,
        IAuditable<TUser>
    {
        //
        // BASE
        //

        public TID ID { get; set; }

        public TypeOfVisibility Visibility { get; set; }

        //
        // AUDITABLE
        //

        public TUser CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public TUser ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        //
        // CONSTRUCTORS
        //

        public ABaseEntityWithID()
        {
            //
            // BASE
            //

            ID = default(TID);
            Visibility = TypeOfVisibility.ACTIVE;

            //
            // AUDITABLE
            //

            AuditableExtensions.Init(this, default(TUser));
        }
    }
}
