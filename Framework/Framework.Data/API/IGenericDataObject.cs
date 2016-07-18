// ============================================================================
// Project: Framework
// Name/Class: IProviderDataObject
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic single object data source.
// ============================================================================

using Framework.Core.API;

namespace Framework.Data.API
{
    public interface IGenericDataObject<TItem> : ICommon
    {
        //
        // Set the object value.
        //

        void Set(TItem item);

        //
        // Get object value.
        //

        TItem Get();

        //
        // Save changes to data source.
        //

        void Save();
    }
}
