// ============================================================================
// Project: Framework
// Name/Class: IProviderDataObject
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic single object data source.
// ============================================================================

using Framework.Core.Api;

namespace Framework.Data.Api
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
