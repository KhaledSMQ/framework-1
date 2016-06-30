// ============================================================================
// Project: Framework
// Name/Class: IModified
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 08/Sep/2015
// Company: Coop4Creativity
// Description: Pattern for classes required modified audit info.
// ============================================================================                    

using System;

namespace Framework.Core.Patterns
{
    public interface IModified<T>
    {
        //
        // Date time stamp for creation date.
        //

        DateTime ModifiedDate { get; set; }

        //
        // User information that created the instance.
        //

        T ModifiedBy { get; set; }
    }
}
