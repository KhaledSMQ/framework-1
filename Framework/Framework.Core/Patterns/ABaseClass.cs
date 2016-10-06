// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;
using Framework.Core.Extensions;

namespace Framework.Core.Patterns
{
    public class ABaseClass<TUser> :
        IVisible,
        IAuditable<TUser>
    {
        //
        // BASE
        //

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

        public ABaseClass()
        {
            //
            // BASE
            //

            Visibility = TypeOfVisibility.ACTIVE;

            //
            // AUDITABLE
            //

            AuditableExtensions.Init(this, default(TUser));
        }
    }
}
