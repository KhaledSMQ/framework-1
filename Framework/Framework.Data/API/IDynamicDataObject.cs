// ============================================================================
// Project: Framework
// Name/Class: IProviderDataObject
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic single object data source.
// ============================================================================

using Framework.Core.Api;
using System;

namespace Framework.Data.Api
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
