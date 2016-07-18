// ============================================================================
// Project: Framework
// Name/Class: IProviderDataObject
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic single object data source.
// ============================================================================

using Framework.Core.API;
using System;

namespace Framework.Data.API
{
    public interface IDynamicDataObject : ICommon
    {
        //
        // PROPERTIES
        //

        Type Entity { get; set; }

        //
        // API
        //
        //
        // Set the object value.
        //

        void Set(object item);

        //
        // Get object value.
        //

        object Get();

        //
        // Save changes to data source.
        //

        void Save();
    }
}
