// ============================================================================
// Project: Framework
// Name/Class: IWrapperDataObject
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service contract for single object sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Factory.Patterns;

namespace Framework.Data.Patterns
{
    public interface IWrapperDataObject<TItem> : ICommon
    {
        //
        // PROPERTIES
        //

        IConfigMap Src { get; set; }

        //
        // SET
        //

        void Set(TItem item);

        //
        // GET
        //

        TItem Get();

        //
        // SAVE
        //

        void Save();
    }
}
