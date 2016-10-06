// ============================================================================
// Project: Framework
// Name/Class: ICreated
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 08/Sep/2015
// Company: Coop4Creativity
// Description: Pattern for classes required created audit info.
// ============================================================================                    

using System;

namespace Framework.Core.Patterns
{
    public interface ICreated<T>
    {
        //
        // Date time stamp for creation date.
        //

        DateTime CreatedDate { get; set; }

        //
        // User information that created the instance.
        //

        T CreatedBy { get; set; }
    }
}
