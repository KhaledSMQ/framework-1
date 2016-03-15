// ============================================================================
// Project: Framework
// Name/Class: IProviderDataObject
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Generic single object data source.
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Data.Patterns
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
